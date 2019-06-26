using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearbyShop.API.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(8, ErrorMessage = "Username must be greater than 8.")]
        [StringLength(20, ErrorMessage = "Username can't be more than 8.")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Confirm password does not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
