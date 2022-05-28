using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBAOseno.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CBAOseno.Core.Models;

namespace CBAOseno.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

         public DbSet<UserRole> UserRole { get; set; }
        //public DbSet<User> User { get; set; }
        public DbSet<GLCategory> GLCategory { get; set; }
        public DbSet<GLAccount> GLAccount { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerAccount> CustomerAccount { get; set; }
		public DbSet<Teller> Teller { get; set; }
        public DbSet<Configuration> Configuration { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*modelBuilder.Entity<User>().HasData(
                new User
                {
                    userId = 1,
                    firstName = "Super",
                    lastName = "Admin",
                    email = "cba@mail.com",
                    Password = "none",
                    gender = Core.Enums.Gender.Any,
                    status = Core.Enums.Status.Enabled,
                    roleName = "Super Admin",
                    isAdmin = true,
                }

                );*/
            modelBuilder.Entity<Configuration>().HasData(
                new Configuration
                {
                    ConfigId = 1,
                    AccountType = Core.Enums.AccountType.Current,
					accountTType = "Current",
                    MinBalance = 0.00M,
                    InterestRate = 0.00M,
                    FinancialDate = DateTime.Now,
                    CoT = 0.00M,
                },
                new
                {
                    ConfigId = 2,
                    AccountType = Core.Enums.AccountType.Savings,
					accountTType = "Savings",
                    MinBalance = 0.00M,
                    InterestRate = 0.00M,
                    FinancialDate = DateTime.Now,
                    CoT = 0.00M,
                },
                new
                {
                    ConfigId = 3,
                    AccountType = Core.Enums.AccountType.Loan,
					accountTType = "Loan",
                    MinBalance = 0.00M,
                    InterestRate = 0.00M,
                    FinancialDate = DateTime.Now,
                    CoT = 0.00M,
                }
                );

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));


                foreach (var property in properties)
                {
                    modelBuilder.Entity(entityType.Name).Property(property.Name).HasColumnType("decimal(18,2)");
                }
            }
        }
    }
}
