using System;
using System.ComponentModel.DataAnnotations;

namespace IPVC_Escuta_Vs11.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "A confirmação da senha não corresponde.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public DateTime RegisterDate { get; set; }
    }
}
