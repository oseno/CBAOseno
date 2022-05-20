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
    public class GLAccountController : Controller
    {
        private readonly IGLAccountOperation _operations;
        public GLAccountController(IGLAccountOperation operations)
        {
            _operations = operations;
        }


        public IActionResult Index()
        {
            var gLAccounts = _operations.GetAllGLAccounts();
            return View(gLAccounts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddGLAccountViewModel model, GLAccount glAccount)
        {
            if (ModelState.IsValid)
            {
                GLAccount newGLAccount = new()
                {
                    GLAccountId = model.GLAccountId,
                    GLAccountName = model.GLAccountName,
					GLAccountBalance = model.GLAccountBalance,
					GLAccountCode = _operations.CreateGlCategoryCode(glAccount),
                    Status = model.Status,
					Categories = model.Categories,
                    //GLAccountAccount = model.GLAccountAccount,
                };

                _operations.Save(newGLAccount);
                //return RedirectToAction("index", new { id = newUser.Id });
                return RedirectToAction("index", "GLAccount", new { area = "" });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var gLAccount = _operations.RetrieveById(id);
            EditGLAccountViewModel editUserViewModel = new EditGLAccountViewModel()
            {
                //GLAccountId = gLAccount.GLAccountId,
                GLAccountName = gLAccount.GLAccountName,
                Status = gLAccount.Status,
				GLAccountCode = gLAccount.GLAccountCode,
				Categories = gLAccount.Categories,
				GLAccountBalance = gLAccount.GLAccountBalance,
            };
            return View(editUserViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var gLAccount = _operations.RetrieveById(id);
            EditGLAccountViewModel editUserViewModel = new EditGLAccountViewModel()
            {
                //GLAccountId = gLAccount.GLAccountId,
                GLAccountName = gLAccount.GLAccountName,
                Status = gLAccount.Status,
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditGLAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                GLAccount gLAccount = _operations.RetrieveById(model.Id);
                //Console.WriteLine(model.Id);
                //gLAccount.GLAccountId = model.GLAccountId;
                gLAccount.GLAccountName = model.GLAccountName;
                gLAccount.Status = model.Status;

                GLAccount updatedGLAccount = _operations.UpdateGLAccount(gLAccount);

                return RedirectToAction("index", "GLAccount", new { area = "" });
            }

            return View(model);
        }
    }
}