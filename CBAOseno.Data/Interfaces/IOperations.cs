using CBAOseno.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBAOseno.Data.Interfaces
{
    public interface IOperations
    {
        //Customer
        Customer Save(Customer item);
        Customer RetrieveById(int id);
        Customer Delete(long id);
        Customer UpdateCustomer(Customer userChanges);
        IEnumerable<Customer> GetAllCustomers();
        Customer GetRoles(Customer user);
        /*
        Task<IEnumerable<UserRole>> GetAllAsync();
         Task AddAsync(UserRole userrole);
         Task<UserRole> GetByIdAsync(int roleId);
         Task<UserRole> UpdateAsync(int roleId, UserRole newUserrole);
        
         */
    }
}
