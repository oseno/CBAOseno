using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CBAOseno.Core.Enums;
namespace CBAOseno.WebApi.ViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
            Claims = new List<string>();
        }
        public string Id { get; set; }

        [Required(ErrorMessage = "Role name is required!")]
        public string RoleName { get; set; }
        [Required]
        public Status Status { get; set; }
        public List<string> Users { get; set; }
        public List<string> Claims { get; set; }
    }
}
