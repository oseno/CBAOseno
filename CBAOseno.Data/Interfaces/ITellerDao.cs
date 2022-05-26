using CBAOseno.Core.Models;
using CBAOseno.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBAOseno.Data.Interfaces
{
    public interface ITellerDao
    {
        //Teller
        Task<List<ApplicationUser>> GetAllTellers();
        Task<List<ApplicationUser>> GetTellersWithNoTills();
        Task<List<Teller>> GetAllTellerDetails();
		Task<List<ApplicationUser>> GetTellersWithTills();
        List<Teller> GetDbTellers();
		//glACC things for TELLER
        Task<List<GLAccount>> GetAllTills();
        Task<List<GLAccount>> GetTillsWithoutTellers();
		
		List<GLAccount> GetAll();

        bool IsGlCategoryIsDeletable(int id);

        GLAccount GetLastGlIn(Categories mainCategory);

        bool AnyGlIn(Categories mainCategory);

        GLAccount GetByName(string Name);

        GLAccount GetById(int Id);

        List<GLAccount> GetAllAssetAccounts();

        List<GLAccount> GetAllIncomeAccounts();

        List<GLAccount> GetAllLiabilityAccounts();

        List<GLAccount> GetAllExpenseAccounts();

        List<GLAccount> GetByMainCategory(Categories mainCategory);
    }
}
