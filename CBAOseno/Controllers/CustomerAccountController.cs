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
    public class CustomerAccountController : Controller
    {
        private readonly ICustomerAccountOperation _operations;
        public CustomerAccountController(ICustomerAccountOperation operations)
        {
            _operations = operations;
        }


        public IActionResult Index()
        {
            var customerAccounts = _operations.GetAllCustomerAccounts();
            return View(customerAccounts);
        }

        [HttpGet]
        public IActionResult Create()
        {
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
                    Customer = model.Customer,
                    Status = model.Status,
                    //CustomerAccountAccount = model.CustomerAccountAccount,
                };

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
                Customer = customerAccount.Customer,
                Status = customerAccount.Status,
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
                Customer = customerAccount.Customer,
                Status = customerAccount.Status,
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
                customerAccount.Customer = model.Customer;
                customerAccount.Status = model.Status;

                CustomerAccount updatedCustomerAccount = _operations.UpdateCustomerAccount(customerAccount);

                return RedirectToAction("index", "CustomerAccount", new { area = "" });
            }

            return View(model);
        }
    }
}