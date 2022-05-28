using CBAOseno.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using CBAOseno.Core.Models;
using CBAOseno.Core.Enums;
using System.Text;
using System.Threading.Tasks;

namespace CBAOseno.Data.Implementations
{
    public class Operations : IOperations
    {
        private readonly ApplicationDbContext db;
        public Operations(ApplicationDbContext db)
        {
            this.db = db;
        }
		//public int GenerateCustomerId(int id)
		public string GenerateCustomerId(string id)
        {
			long newId = 0;
            var customerList = db.Customer.ToList().OrderByDescending(c=>c.CustomerId);

            if (customerList.Any())
            {
                var lastId = customerList.First().CustomerId;
                var stringLastId = lastId.ToString();
                //Get the main id
                newId = lastId + 1;
            }
			string stringId = newId.ToString("D4");
			return stringId;
			//int newid = 0000;
			//if (newid < 1000)
			//{
				//newid++.ToString("D4");
			//}
			//var now = DateTime.Now;
			//var zeroDate = DateTime.MinValue.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second).AddMilliseconds(now.Millisecond);
			//int newCustomerId = (int)(zeroDate.Ticks / 10000);
			//int newCustomerId = newid;
            //return newCustomerId;
			
        }
        public Customer Delete(long id)
        {
            Customer customer = db.Customer.Find(id);
            if (customer != null)
            {
                db.Customer.Remove(customer);
                db.SaveChanges();
            }
            return customer;
        }

        public Customer RetrieveById(int id)
        {
            Customer customer = db.Customer.Find(id);
            return customer;
        }

        public Customer Save(Customer customer)
        {
            db.Customer.Add(customer);
            db.SaveChanges();
            return customer;
        }


        public Customer UpdateCustomer(Customer customerChanges)
        {
            var customer = db.Customer.Attach(customerChanges);
            customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return customerChanges;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = db.Customer.ToList();
            return customers;
        }
    }
}
