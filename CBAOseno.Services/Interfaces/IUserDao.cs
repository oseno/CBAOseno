using CBAOseno.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBAOseno.Services.Interfaces
{
    public interface IUserDao
    {
        string GeneratePassword();
        string GenerateUserName(string firstname, string secondname);
        Task SendEmailAsync(MailRequest mailRequest);
        /*Task SendEmailAsync(string email, string subject, string htmlMessage);
         Task<IEnumerable<UserRole>> GetAllAsync();
         Task AddAsync(UserRole userrole);
         Task<UserRole> GetByIdAsync(int roleId);
         Task<UserRole> UpdateAsync(int roleId, UserRole newUserrole);
         Task DeleteAsync(int roleId); */
    }
}
