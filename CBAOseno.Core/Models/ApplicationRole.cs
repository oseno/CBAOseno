using CBAOseno.Core.Enums;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CBAOseno.Core.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole():base() { }
        public ApplicationRole(string name) : base(name) { }
        public Status Status { get; set; }
    }
}
