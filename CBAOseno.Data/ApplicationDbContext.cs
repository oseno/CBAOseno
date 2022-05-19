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
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    RoleId = 1,
                    RoleName = "Super Admin",
                    Status = Core.Enums.Status.Enabled,
                }

                );
   }

    }
}
