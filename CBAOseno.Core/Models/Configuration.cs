using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBAOseno.Core.Enums;

namespace CBAOseno.Core.Models
{
    public class Configuration
    {
        [Key]
		public int ConfigId { get; set; }
		
        public AccountType AccountType { get; set; }
		
		public string accountTType { get; set; }
		
		[Display(Name = "Minimum Balance")]
        [DataType(DataType.Currency)]
		public decimal MinBalance { get; set; }
		
		public decimal CoT { get; set; }

        public decimal InterestRate { get; set; }
		
		public DateTime FinancialDate { get; set; }
    }
}
