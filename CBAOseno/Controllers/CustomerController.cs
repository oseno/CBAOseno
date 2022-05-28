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
    public class CustomerController : Controller
    {
        private readonly IOperations _operations;
        private readonly ApplicationDbContext context;
        public CustomerController(IOperations operations, ApplicationDbContext context)
        {
            _operations = operations;
            this.context = context;
        }


        public IActionResult Index()
        {
            var customers = _operations.GetAllCustomers();
            return View(customers);
        }
		[HttpPost]
		public IActionResult Delete(long id)
		{
			Customer customer = _operations.Delete(id);
			return RedirectToAction("index", "customer", new { area = "" });
		}
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                Customer newCustomer = new()
                {
                    CustomerId = model.CustomerId,
					NewCustomerId = _operations.GenerateCustomerId(model.NewCustomerId),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    Email = model.Email,
                    Status = model.Status,
                    //CustomerAccount = model.CustomerAccount,
                };

                _operations.Save(newCustomer);
                //return RedirectToAction("index", new { id = newUser.Id });
                return RedirectToAction("index", "customer", new { area = "" });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var customer = _operations.RetrieveById(id);
            EditCustomerViewModel editUserViewModel = new EditCustomerViewModel()
            {
                //CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Gender = customer.Gender,
                Email = customer.Email,
                Status = customer.Status,
                CustomerAccount = customer.CustomerAccount,
            };
            return View(editUserViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = _operations.RetrieveById(id);
            EditCustomerViewModel editUserViewModel = new EditCustomerViewModel()
            {
                //CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Gender = customer.Gender,
                Email = customer.Email,
                Status = customer.Status,
                NewCustomerId = customer.NewCustomerId,
                CustomerAccount = customer.CustomerAccount,
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _operations.RetrieveById(model.Id);
                //Console.WriteLine(model.Id);
                //customer.CustomerId = model.CustomerId;
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.Gender = model.Gender;
                customer.Email = model.Email;
                customer.Status = model.Status;
                customer.NewCustomerId = model.NewCustomerId;
                customer.CustomerAccount = model.CustomerAccount;

                Customer updatedCustomer = _operations.UpdateCustomer(customer);

                return RedirectToAction("index", "customer", new { area = "" });
            }

            return View(model);
        }
		
		[HttpGet]
		public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return ViewBag.ErrorMessage = $"account with Id = {id} cannot be found"; ;
            }
            Customer config = await context.Customer.FindAsync(id);
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
            Customer config = await context.Customer.FindAsync(id);
            context.Customer.Remove(config);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}