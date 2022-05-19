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
