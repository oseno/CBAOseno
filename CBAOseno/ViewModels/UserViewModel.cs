using CBAOseno.Core.Enums;
using System.ComponentModel.DataAnnotations;
namespace CBAOseno.WebApi.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Status Status { get; set; }
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",
          ErrorMessage = "Password fields do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
