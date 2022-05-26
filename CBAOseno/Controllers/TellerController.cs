using Microsoft.AspNetCore.Mvc;
using CBAOseno.Services.Interfaces;
using CBAOseno.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web.Mvc;
using System.Threading.Tasks;
using CBAOseno.Core.Models;
using CBAOseno.WebApi.ViewModels;
using CBAOseno.Data;
using System.Globalization;
using System.Net;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CBAOseno.WebApi.Controllers
{
    public class TellerController : Controller
    {
		private readonly ITellerDao _tellerdao;
		private readonly ApplicationDbContext context;
        public TellerController(ITellerDao tellerdao, ApplicationDbContext _context)
        {
            _tellerdao = tellerdao;
			context = _context;
        }

        public async Task<ActionResult> Index()
        {
            var tellerDetails = await _tellerdao.GetAllTellerDetails();
            var viewModel = new List<TellerViewModel>();

            foreach (var detail in tellerDetails)
            {
                TellerViewModel data;
                if (detail.GLAccountId == 0)
                {
                    data = new TellerViewModel
                    {
                        GLAccountName = "--",
                        AccountBalance = "--",
                        Email = context.Users.Find(detail.UserId).Email,
                        HasDetails = false,
                        IsDeletable = false
                    };
                    viewModel.Add(data);
                }
                else
                {
                    var applicationUser = context.Users.Find(detail.UserId);
                    data = new TellerViewModel
                    {
                        GLAccountName = detail.GLAccount.GLAccountName,
                        Id = detail.Id,
                        Email = applicationUser.Email,
                        AccountBalance = detail.GLAccount.GLAccountBalance.ToString(CultureInfo.InvariantCulture)
                    };
                    viewModel.Add(data);
                }
            }


            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Assign()
        {
           ViewBag.Users = new SelectList(await _tellerdao.GetTellersWithNoTills(), "Id", "Email");
			Thread.Sleep(4000);
            ViewBag.GlAccounts = new SelectList(await _tellerdao.GetTillsWithoutTellers(), "ID", "AccountName");

            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Assign(Teller tillAccount)
        {
            if (ModelState.IsValid)
            {
                context.Teller.Add(tillAccount);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Users = new SelectList(await _tellerdao.GetTellersWithNoTills(), "Id", "UserName", tillAccount.UserId);
            ViewBag.GlAccounts = new SelectList(await _tellerdao.GetTellersWithNoTills(), "ID", "AccountName", tillAccount.GLAccountId);
            return View(tillAccount);
        }

       public async Task<ActionResult> Unassign(int? id)
        {
            if (id == null)
            {
                return ViewBag.ErrorMessage = $"Teller with Id = {id} cannot be found"; ;
            }
            Teller tillAccount = await context.Teller.FindAsync(id);
            if (tillAccount == null)
            {
                return View("NotFound");
            }
            return View(tillAccount);
        }

        [HttpPost, ActionName("Unassign")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Teller tillAccount = await context.Teller.FindAsync(id);
            context.Teller.Remove(tillAccount);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
       
	   
    }
}
