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
    public class GLAccountOperation : IGLAccountOperation
    {
        private readonly ApplicationDbContext db;
        public GLAccountOperation(ApplicationDbContext db)
        {
            this.db = db;
        }
        public GLAccount Delete(long id)
        {
            GLAccount gLAccount = db.GLAccount.Find(id);
            if (gLAccount != null)
            {
                db.GLAccount.Remove(gLAccount);
                db.SaveChanges();
            }
            return gLAccount;
        }

        public GLAccount RetrieveById(int id)
        {
            GLAccount gLAccount = db.GLAccount.Find(id);
            return gLAccount;
        }

        public GLAccount Save(GLAccount gLAccount)
        {
            db.GLAccount.Add(gLAccount);
            db.SaveChanges();
            return gLAccount;
        }

        public GLAccount GetRoles(GLAccount gLAccount)
        {
            throw new NotImplementedException();
        }

        public GLAccount UpdateGLAccount(GLAccount gLAccountsChanges)
        {
            var gLAccount = db.GLAccount.Attach(gLAccountsChanges);
            gLAccount.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return gLAccountsChanges;
        }

        public IEnumerable<GLAccount> GetAllGLAccounts()
        {
            var gLAccounts = db.GLAccount.ToList();
            return gLAccounts;
        }
    }
}
