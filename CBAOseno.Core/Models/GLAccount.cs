using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBAOseno.Core.Enums;

namespace CBAOseno.Core.Models
{
    public class GLAccount
    {
        [Key]
        public int GLAccountId { get; set; }

        public string GLAccountName { get; set; }

        public Status Status { get; set; }

        public GLCategory GLCategory { get; set; }
    }
}
