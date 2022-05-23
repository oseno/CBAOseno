using CBAOseno.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBAOseno.Core.Enums;
using System.Threading.Tasks;

namespace CBAOseno.Data.Interfaces
{
    public interface ICustomerAccountOperation
    {
        //Customer Account
        CustomerAccount Save(CustomerAccount item);
        CustomerAccount RetrieveById(int id);
        CustomerAccount Delete(long id);
        CustomerAccount UpdateCustomerAccount(CustomerAccount userChanges);
        IEnumerable<CustomerAccount> GetAllCustomerAccounts();
        CustomerAccount GetRoles(CustomerAccount user);
       //string CreateAccountNumber(AccountType accountType, CustomerAccount customerAccount);
    }
}
