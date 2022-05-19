using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBAOseno.Core.Enums;

namespace CBAOseno.Core.Models
{
    public class CustomerAccount
    {
        [Key]
        public int AccountId { get; set; }
        public Customer Customer { get; set; }
        public Status Status { get; set; }
    }
}
