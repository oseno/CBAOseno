﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CBAOseno.Core.Enums;
using CBAOseno.Core.Models;

namespace CBAOseno.WebApi.ViewModels
{
    public class AddGLCategoryViewModel
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
		
		public string CategoryDescription  { get; set; }
		
		public long CategoryCode { get; set; }

        public Status Status { get; set; }
		
		public Categories Categories { get; set; }

        // ICollection<GLAccount> GLAccount { get; set; }
    }
}

