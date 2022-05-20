using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBAOseno.Core.Enums;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CBAOseno.Core.Models
{
    public class Teller
    {
        [Required]
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public int GLAccountId { get; set; }

        public GLAccount GLAccount { get; set; }
    }
}
