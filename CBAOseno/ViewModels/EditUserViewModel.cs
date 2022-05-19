using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CBAOseno.Core.Enums;
namespace CBAOseno.WebApi.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }
        public string Id { get; set; }

        
       // public string UserName { get; set; }
        [Required] 
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public List<string> Claims { get; set; }
        public List<string> Roles { get; set; }
    }
}
