using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBAOseno.Core.Enums;

namespace CBAOseno.Core.Models
{
    public class UserRole
    {
        [Key]
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string Functions { get; set; }

        public Status Status { get; set; }
    }
}
