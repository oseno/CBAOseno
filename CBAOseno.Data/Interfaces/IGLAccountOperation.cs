using CBAOseno.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBAOseno.Data.Interfaces
{
    public interface IGLAccountOperation
    {
        //GLAccount
        GLAccount Save(GLAccount item);
        GLAccount RetrieveById(int id);
        GLAccount Delete(long id);
        GLAccount UpdateGLAccount(GLAccount userChanges);
        IEnumerable<GLAccount> GetAllGLAccounts();
        GLAccount GetRoles(GLAccount user);
    
    }
}
