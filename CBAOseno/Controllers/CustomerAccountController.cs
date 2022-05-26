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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CBAOseno.WebApi.Controllers
{
    public class CustomerAccountController : Controller
    {
        private readonly ICustomerAccountOperation _operations;
        private readonly ApplicationDbContext context;
        public CustomerAccountController(ICustomerAccountOperation operations,  ApplicationDbContext context)
        {
            _operations = operations;
			this.context = context;
        }


        public IActionResult Index()
        {
            var customerAccounts = _operations.GetAllCustomerAccounts();
            return View(customerAccounts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.NewCustomerId = new SelectList(context.Customer, "NewCustomerId", "FirstName", "LastName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddCustomerAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                CustomerAccount newCustomerAccount = new()
                {
                    AccountId = model.AccountId,
					AccountType = model.AccountType,
                    //NewCustomerId =  new SelectList(context.Customer, "NewCustomerId","FirstName","LastName"),
                    AccountStatus = model.AccountStatus,
					AccountName = model.AccountName,
					AccountBalance = model.AccountBalance,
                    //AccountNumber = _operations.CreateAccountNumber(customerAccount.AccountType, customerAccount),
                };
                ViewBag.NewCustomerId = new SelectList(context.Customer, "NewCustomerId", "FirstName", "LastName", model.NewCustomerId.ToString());
                _operations.Save(newCustomerAccount);
                //return RedirectToAction("index", new { id = newUser.Id });
                return RedirectToAction("index", "CustomerAccount", new { area = "" });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var customerAccount = _operations.RetrieveById(id);
            EditCustomerAccountViewModel editUserViewModel = new EditCustomerAccountViewModel()
            {
                //CustomerAccountId = customerAccount.CustomerAccountId,
                AccountType = customerAccount.AccountType,
                    //Customer = customerAccount.Customer.NewCustomerId,
                    AccountStatus = customerAccount.AccountStatus,
					AccountName = customerAccount.AccountName,
					AccountBalance = customerAccount.AccountBalance,
            };
            return View(editUserViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customerAccount = _operations.RetrieveById(id);
            EditCustomerAccountViewModel editUserViewModel = new EditCustomerAccountViewModel()
            {
                //CustomerAccountId = customerAccount.CustomerAccountId,
                AccountName = customerAccount.AccountName,
                AccountStatus = customerAccount.AccountStatus,
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditCustomerAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                CustomerAccount customerAccount = _operations.RetrieveById(model.Id);
                //Console.WriteLine(model.Id);
                //customerAccount.CustomerAccountId = model.CustomerAccountId;
                customerAccount.AccountName = model.AccountName;
                customerAccount.AccountStatus = model.AccountStatus;

                CustomerAccount updatedCustomerAccount = _operations.UpdateCustomerAccount(customerAccount);

                return RedirectToAction("index", "CustomerAccount", new { area = "" });
            }

            return View(model);
        }
    }
}