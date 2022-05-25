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
        public ConfigurationController(IConfigDao operations)
        {
            _operations = operations;
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
                    AccountType = model.AccountType,
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
                //AccountType = Configuration.AccountType,
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
                AccountType = Configuration.AccountType,
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
                Configuration.AccountType = model.AccountType;

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
                AccountType = Configuration.AccountType,
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
                Configuration.AccountType = model.AccountType;

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
                AccountType = Configuration.AccountType,
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
                Configuration.AccountType = model.AccountType;

                Configuration updatedConfiguration = _operations.UpdateConfiguration(Configuration);

                return RedirectToAction("index", "Configuration", new { area = "" });
            }

            return View(model);
        }
    }
}