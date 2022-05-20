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
    public class GLCategoryOperation : IGLCategoryOperation
    {
        private readonly ApplicationDbContext db;
        public GLCategoryOperation(ApplicationDbContext db)
        {
            this.db = db;
        }
		
	
       /* public long CreateGlCategoryCode(GLCategory gLCategory)
        {
            long newGlCode = 10;
            Categories mainGl = gLCategory.Categories;

            var categoryList = db.GLCategory.ToList().OrderByDescending(c=>c.CategoryId);

            if (categoryList.Any())
            {
                var lastGlCode = categoryList.First().CategoryCode;
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
		*/
		
		
		
		
		
		
		
		
		
		
		
        public GLCategory Delete(long id)
        {
            GLCategory gLCategory = db.GLCategory.Find(id);
            if (gLCategory != null)
            {
                db.GLCategory.Remove(gLCategory);
                db.SaveChanges();
            }
            return gLCategory;
        }

        public GLCategory RetrieveById(int id)
        {
            GLCategory gLCategory = db.GLCategory.Find(id);
            return gLCategory;
        }

        public GLCategory Save(GLCategory gLCategory)
        {
            db.GLCategory.Add(gLCategory);
            db.SaveChanges();
            return gLCategory;
        }

        public GLCategory GetRoles(GLCategory gLCategory)
        {
            throw new NotImplementedException();
        }

        public GLCategory UpdateGLCategory(GLCategory gLCategoryChanges)
        {
            var gLCategory = db.GLCategory.Attach(gLCategoryChanges);
            gLCategory.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return gLCategoryChanges;
        }

        public IEnumerable<GLCategory> GetAllGLCategorys()
        {
            var gLCategorys = db.GLCategory.ToList();
            return gLCategorys;
        }
    }
}
