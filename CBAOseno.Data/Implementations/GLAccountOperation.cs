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
		
		public long CreateGlCategoryCode(GLAccount glAccount)
        {
            long newGlCode = 10;
            Categories mainGl = glAccount.Categories;

            var categoryList = db.GLAccount.ToList().OrderByDescending(c=>c.GLAccountId);

            if (categoryList.Any())
            {
                var lastGlCode = categoryList.First().GLAccountCode;
                var stringLastGlCode = lastGlCode.ToString();
                //Get the main GlCode

                int endIndex = stringLastGlCode.Length - 3;
                string mainGlCode = stringLastGlCode.Substring(3, endIndex);

                lastGlCode = Convert.ToInt64(mainGlCode);

                newGlCode = lastGlCode + 10;
                
            }

            string stringGlCode = newGlCode.ToString();
            long finalGlCode;

            switch (mainGl)
            {
                case Categories.Asset:
                    finalGlCode = Convert.ToInt64(MainCategoryCodes.AssetCode + stringGlCode);
                    break;
                case Categories.Capital:
                    finalGlCode = Convert.ToInt64(MainCategoryCodes.CapitalCode + stringGlCode);
                    break;
                case Categories.Expense:
                    finalGlCode = Convert.ToInt64(MainCategoryCodes.ExpenseCode + stringGlCode);
                    break;
                case Categories.Income:
                    finalGlCode = Convert.ToInt64(MainCategoryCodes.IncomeCode + stringGlCode);
                    break;
                case Categories.Liability:
                    finalGlCode = Convert.ToInt64(MainCategoryCodes.LiabilityCode + stringGlCode);
                    break;
                default:
                    finalGlCode = 000;
                    break;
            }

            return finalGlCode;
        }

        

    public class MainCategoryCodes
    {
        public static string AssetCode = "100";
        public static string LiabilityCode = "200";
        public static string CapitalCode = "300";
        public static string IncomeCode = "400";
        public static string ExpenseCode = "500";
    }
    }
}
