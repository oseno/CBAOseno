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
		public int GenerateCustomerId(int id)
        {
			var now = DateTime.Now;
			var zeroDate = DateTime.MinValue.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second).AddMilliseconds(now.Millisecond);
			int newCustomerId = (int)(zeroDate.Ticks / 10000);
            return newCustomerId;
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

        public Customer GetRoles(Customer customer)
        {
            throw new NotImplementedException();
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
