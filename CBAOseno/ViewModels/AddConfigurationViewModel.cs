using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CBAOseno.Core.Enums;
using CBAOseno.Core.Models;

namespace CBAOseno.WebApi.ViewModels
{
	public class AddConfigurationViewModel
	{
		[Key]
		public int ConfigId { get; set; }

		public AccountType AccountType { get; set; }

		public string accountTType { get; set;}
		
		[Display(Name = "Minimum Balance")]
        [DataType(DataType.Currency)]
		public decimal MinBalance { get; set; }
		
		public decimal CoT { get; set; }

        public decimal InterestRate { get; set; }
		
		public DateTime FinancialDate { get; set; }
    }
}

