using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tahuan.BookStore.Models
{
    [Keyless]
    public class SignupUserModel
    {
        [Required(ErrorMessage ="Enter your first name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage ="Enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Enter your email")]
        [Display(Name ="Email address")]
        [EmailAddress(ErrorMessage ="Enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter a strong password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm your password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
