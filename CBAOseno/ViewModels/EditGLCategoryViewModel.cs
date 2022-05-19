using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CBAOseno.Core.Enums;
using CBAOseno.Core.Models;

namespace CBAOseno.WebApi.ViewModels
{
    public class EditGLCategoryViewModel : AddGLCategoryViewModel
    {
        public int Id { get; set; }
    }
}
