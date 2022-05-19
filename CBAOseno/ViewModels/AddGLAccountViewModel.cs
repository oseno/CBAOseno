using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CBAOseno.Core.Enums;
using CBAOseno.Core.Models;

namespace CBAOseno.WebApi.ViewModels
{
    public class AddGLAccountViewModel
    {
        [Key]
        public int GLAccountId { get; set; }

        public string GLAccountName { get; set; }

        public Status Status { get; set; }

        public GLCategory GLCategory { get; set; }
    }
}

