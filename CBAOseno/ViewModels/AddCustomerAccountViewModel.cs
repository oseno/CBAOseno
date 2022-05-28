using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CBAOseno.Core.Enums;
using CBAOseno.Core.Models;

namespace CBAOseno.WebApi.ViewModels
{
    public class AddCustomerAccountViewModel
    {
        [Key]
        public int AccountId { get; set; }
		
		[Required]
        [Display(Name = "Account Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Enter Only Characters!")]
        public string AccountName { get; set; }
		
        public AccountType AccountType { get; set; }
		
        public AccountStatus AccountStatus { get; set; }
		
		[Display(Name = "Account Number")]
        [RegularExpression(@"^[0-9]*$")]
        public string AccountNumber { get; set; }
		
        [Display(Name = "Account Balance")]
        [DataType(DataType.Currency)]
        public decimal AccountBalance { get; set; }
		
		public string NewCustomerId { get; set; }
        //public virtual Customer Customer { get; set; }
        public virtual Customer Customer { get; set; }
    }
}

