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
		public string CreateAccountNumber(AccountType accounttype, CustomerAccount customerAccount)
        {
			Random rd = new Random();
			long rand_num = rd.Next(1000,9999);
			CustomerAccount customerId = customerAccount;
			string stringId = customerAccount.NewCustomerId;
           // string longId = String.Format("00{0}", r =.ToString("D9"));
            if (accounttype == AccountType.Savings)
            {
                string accountNumber = AccountTypes.SavingsId + stringId + rand_num.ToString();
                return accountNumber.ToString();
            }

            if (accounttype == AccountType.Current)
            {
                string accountNumber = AccountTypes.CurrentId + stringId + rand_num.ToString();
                return accountNumber.ToString();
            }
            if (accounttype == AccountType.Loan)
            {
                string accountNumber = AccountTypes.LoanId + stringId + rand_num.ToString();
                return accountNumber.ToString();
            }

            return "";
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
		public static class AccountTypes
		{
        public static long SavingsId = 100;
        public static long CurrentId = 200;
        public static long LoanId = 300;
		}
    }
}
