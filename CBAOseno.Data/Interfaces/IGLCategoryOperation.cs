using CBAOseno.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBAOseno.Data.Interfaces
{
    public interface IGLCategoryOperation
    {
        //GLCategory
        GLCategory Save(GLCategory item);
        GLCategory RetrieveById(int id);
        GLCategory Delete(long id);
        GLCategory UpdateGLCategory(GLCategory userChanges);
        IEnumerable<GLCategory> GetAllGLCategorys();
        GLCategory GetRoles(GLCategory user);
		//long CreateGlCategoryCode(GLCategory glCategory);
    }
}
