using System.ComponentModel.DataAnnotations;
using CBAOseno.Core.Enums;
namespace CBAOseno.WebApi.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
