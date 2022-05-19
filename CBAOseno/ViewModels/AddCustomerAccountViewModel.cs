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
        public Customer Customer { get; set; }
        public Status Status { get; set; }
    }
}

