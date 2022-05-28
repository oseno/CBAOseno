using Microsoft.AspNetCore.Mvc;
using CBAOseno.Services.Interfaces;
using CBAOseno.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CBAOseno.Core.Models;
using CBAOseno.WebApi.ViewModels;
using CBAOseno.Data;

namespace CBAOseno.WebApi.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly IConfigDao _operations;
        private readonly ApplicationDbContext context;
        public ConfigurationController(IConfigDao operations, ApplicationDbContext _context)
        {
            _operations = operations;
			context = _context;
        }


        public IActionResult Index()
        {
            var Configurations = _operations.GetAllConfigurations();
            return View(Configurations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddConfigurationViewModel model, Configuration Configuration)
        {
            if (ModelState.IsValid)
            {
                Configuration newConfiguration = new()
                {
                    ConfigId = model.ConfigId,
                    InterestRate = model.InterestRate,
                    MinBalance = model.MinBalance,
                    accountTType = model.accountTType,
                    FinancialDate = model.FinancialDate,
                };
                _operations.Save(newConfiguration);
                return RedirectToAction("index", "Configuration", new { area = "" });
            }

            return View(model);
        }

        /*[HttpGet]
        public IActionResult Detail(int id)
        {
            var Configuration = _operations.RetrieveById(id);
            EditConfigurationViewModel editUserViewModel = new EditConfigurationViewModel()
            {
                MinBalance = Configuration.MinBalance,
				InterestRate = Configuration.InterestRate,
                //accountTType = Configuration.accountTType,
            };
            return View(editUserViewModel);
        }*/

        [HttpGet]
        public IActionResult Savings(int id)
        {
            var Configuration = _operations.RetrieveById(id);
            EditConfigurationViewModel editUserViewModel = new EditConfigurationViewModel()
            {
                MinBalance = Configuration.MinBalance,
                InterestRate = Configuration.InterestRate,
                accountTType = Configuration.accountTType,
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public IActionResult Savings(EditConfigurationViewModel model)
        {
            if (ModelState.IsValid)
            {
                Configuration Configuration = _operations.RetrieveById(model.Id);
                Configuration.InterestRate = model.InterestRate;
                Configuration.MinBalance = model.MinBalance;
                Configuration.accountTType = model.accountTType;

                Configuration updatedConfiguration = _operations.UpdateConfiguration(Configuration);

                return RedirectToAction("index", "Configuration", new { area = "" });
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Current(int id)
        {
            var Configuration = _operations.RetrieveById(id);
            EditConfigurationViewModel editUserViewModel = new EditConfigurationViewModel()
            {
                MinBalance = Configuration.MinBalance,
                InterestRate = Configuration.InterestRate,
                accountTType = Configuration.accountTType,
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public IActionResult Current(EditConfigurationViewModel model)
        {
            if (ModelState.IsValid)
            {
                Configuration Configuration = _operations.RetrieveById(model.Id);
                Configuration.InterestRate = model.InterestRate;
                Configuration.MinBalance = model.MinBalance;
                Configuration.accountTType = model.accountTType;

                Configuration updatedConfiguration = _operations.UpdateConfiguration(Configuration);

                return RedirectToAction("index", "Configuration", new { area = "" });
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Configuration = _operations.RetrieveById(id);
            EditConfigurationViewModel editUserViewModel = new EditConfigurationViewModel()
            {
                MinBalance = Configuration.MinBalance,
                InterestRate = Configuration.InterestRate,
                accountTType = Configuration.accountTType,
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditConfigurationViewModel model)
        {
            if (ModelState.IsValid)
            {
                Configuration Configuration = _operations.RetrieveById(model.Id);
                Configuration.InterestRate = model.InterestRate;
                Configuration.MinBalance = model.MinBalance;
                Configuration.accountTType = model.accountTType;

                Configuration updatedConfiguration = _operations.UpdateConfiguration(Configuration);

                return RedirectToAction("index", "Configuration", new { area = "" });
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Loan(int id)
        {
            var Configuration = _operations.RetrieveById(id);
            EditConfigurationViewModel editUserViewModel = new EditConfigurationViewModel()
            {
                MinBalance = Configuration.MinBalance,
                InterestRate = Configuration.InterestRate,
                accountTType = Configuration.accountTType,
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public IActionResult Loan(EditConfigurationViewModel model)
        {
            if (ModelState.IsValid)
            {
                Configuration Configuration = _operations.RetrieveById(model.Id);
                Configuration.InterestRate = model.InterestRate;
                Configuration.MinBalance = model.MinBalance;
                Configuration.accountTType = model.accountTType;

                Configuration updatedConfiguration = _operations.UpdateConfiguration(Configuration);

                return RedirectToAction("index", "Configuration", new { area = "" });
            }

            return View(model);
        }
		
		[HttpGet]
		public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return ViewBag.ErrorMessage = $"configuration with Id = {id} cannot be found"; ;
            }
            Configuration config = await context.Configuration.FindAsync(id);
            if (config == null)
            {
                return View("NotFound");
            }
            return View(config);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Configuration config = await context.Configuration.FindAsync(id);
            context.Configuration.Remove(config);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}