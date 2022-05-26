using CBAOseno.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using CBAOseno.Core.Models;
using CBAOseno.Core.Enums;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CBAOseno.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CBAOseno.Services.Interfaces;
using CBAOseno.Services.Implementations;
using Microsoft.EntityFrameworkCore;

namespace CBAOseno.Data.Implementations
{
    public class TellerDao : ITellerDao
    {
        private readonly ApplicationDbContext context;
		private readonly UserManager<ApplicationUser> userManager;
        public TellerDao(ApplicationDbContext _context, UserManager<ApplicationUser> _userManager)
        {
            context = _context;
			userManager = _userManager;
        }
		  public async Task<List<Teller>> GetAllTellerDetails()
        {
            //var output = new List<Teller>();
			List<Teller> output = new List<Teller>();
            var tillsWithTellers = GetDbTellers();
            var tellersWithoutTill = await GetTellersWithNoTills();
            //Thread.Sleep(7000);
            //adding all tellers without a till account
            foreach (var teller in tellersWithoutTill)
            {
                output.Add(new Teller { UserId = teller.Id, GLAccountId = 0 });
                //  output.Add(new Teller { UserId = teller.Id });
            }
            //adding all tellers with a till account
            output.AddRange(tillsWithTellers);
            return output;
        }

        public async Task<List<ApplicationUser>> GetAllTellers()
        {
            var users = userManager.Users;

            List<ApplicationUser> tellers = new List<ApplicationUser>();

            //Thread.Sleep(4000);
            foreach (var user in users)
            {
                var usersInRole = await userManager.IsInRoleAsync(user, "teller");
                if (usersInRole)
                {
                    //Thread.Sleep(4000);
                    tellers.Add(user);
                }

				//var tills = context.GLAccount.Where(c => c.GLAccountName.ToLower().Contains("till")).ToList();
				//return tills;
                //var isInTellerRole = userManager.IsInRoleAsync(user, "teller");
                //if (isInTellerRole)
                //{
                //  tellers.Add(user);
                //}
            }

            return (tellers);
        }

        public List<Teller> GetDbTellers()
        {
            return context.Teller.Include(x => x.GLAccount).ToList();
        }

        public async Task<List<ApplicationUser>> GetTellersWithNoTills()
        {
            var tellers = await GetAllTellers();
            var tillAccounts = context.Teller.ToList();
            var result = new List<ApplicationUser>();

            foreach (var teller in tellers)
            {
                if (!tillAccounts.Any(c => c.UserId == teller.Id))
                {
                    result.Add(teller);
                }
            }


            return result;
        }
        //gl implementation
        public async Task<List<GLAccount>> GetTillsWithoutTellers()
        {
            var output = new List<GLAccount>();
            List<GLAccount> allTills = await GetAllTills();
            var tillAccount = context.Teller.ToList();

            foreach (var till in allTills)
            {
               if (!tillAccount.Any(c => c.GLAccountId == till.GLAccountId))
               { 
                    output.Add(till);
              }
            }

            return output;
        }
		public async Task<List<ApplicationUser>> GetTellersWithTills()
		{
			var tellers = await GetAllTellers();
			var tillAccounts = context.Teller.ToList();
			var result = new List<ApplicationUser>();
			foreach (var teller in tellers)
			{
				if(tillAccounts.Any(c => c.UserId == teller.Id))
				{
					result.Add(teller);
				}
			}
			return result;
		}
        public async Task<List<GLAccount>> GetAllTills()
        {
            //var tills = context.GLAccount.Where(c => c.GLAccountName.ToLower().Contains("till")).ToList();
            var tills = context.GLAccount.Where(c => c.GLAccountName.ToLower().Contains("till")).ToList();
            return tills;
        }
        public bool AnyGlIn(Categories mainCategory)
        {
            return context.GLAccount.Any(gl => gl.GLCategory.Categories == mainCategory);
        }

        public List<GLAccount> GetAll()
        {
            var glAccountList = context.GLAccount.ToList();
            return glAccountList;
        }

        public List<GLAccount> GetAllAssetAccounts()
        {
            var output = context.GLAccount.Where(c => c.GLCategory.Categories == Categories.Asset).ToList();

            return output;
        }

        public List<GLAccount> GetAllExpenseAccounts()
        {
            var output = context.GLAccount.Where(c => c.GLCategory.Categories == Categories.Expense).ToList();

            return output;
        }

        public List<GLAccount> GetAllIncomeAccounts()
        {
            var output = context.GLAccount.Where(c => c.GLCategory.Categories == Categories.Income).ToList();

            return output;
        }

        public List<GLAccount> GetAllLiabilityAccounts()
        {
            var output = context.GLAccount.Where(c => c.GLCategory.Categories == Categories.Liability).ToList();

            return output;
        }

        

        public GLAccount GetById(int Id)
        {
            var glAccount = context.GLAccount.SingleOrDefault(c => c.GLAccountId == Id);

            return glAccount;
        }

        public List<GLAccount> GetByMainCategory(Categories mainCategory)
        {
            return context.GLAccount.Where(a => a.GLCategory.Categories == mainCategory).ToList();

        }

        public GLAccount GetByName(string Name)
        {
            var glAccountByName = context.GLAccount.SingleOrDefault(c => c.GLAccountName == Name);

            return glAccountByName;
        }

        public GLAccount GetLastGlIn(Categories mainCategory)
        {
            return context.GLAccount.Where(g => g.GLCategory.Categories == mainCategory).OrderByDescending(a => a.GLAccountId).First();
        }


      public bool IsGlCategoryIsDeletable(int id)
        {
            return GetAll().Any(c => c.GLAccountId == id);
        }
	
        
	
    }
}

