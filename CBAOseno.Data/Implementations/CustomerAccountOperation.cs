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
    public class CustomerAccountOperation : ICustomerAccountOperation
    {
        private readonly ApplicationDbContext db;
        public CustomerAccountOperation(ApplicationDbContext db)
        {
            this.db = db;
        }
        public CustomerAccount Delete(long id)
        {
            CustomerAccount customerAccount = db.CustomerAccount.Find(id);
            if (customerAccount != null)
            {
                db.CustomerAccount.Remove(customerAccount);
                db.SaveChanges();
            }
            return customerAccount;
        }

        public CustomerAccount RetrieveById(int id)
        {
            CustomerAccount customerAccount = db.CustomerAccount.Find(id);
            return customerAccount;
        }

        public CustomerAccount Save(CustomerAccount customerAccount)
        {
            db.CustomerAccount.Add(customerAccount);
            db.SaveChanges();
            return customerAccount;
        }

        public CustomerAccount GetRoles(CustomerAccount customerAccount)
        {
            throw new NotImplementedException();
        }

        public CustomerAccount UpdateCustomerAccount(CustomerAccount customerAccountChanges)
        {
            var customerAccount = db.CustomerAccount.Attach(customerAccountChanges);
            customerAccount.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return customerAccountChanges;
        }

        public IEnumerable<CustomerAccount> GetAllCustomerAccounts()
        {
            var customerAccounts = db.CustomerAccount.ToList();
            return customerAccounts;
        }
    }
}
