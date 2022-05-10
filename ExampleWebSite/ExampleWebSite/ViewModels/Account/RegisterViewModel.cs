using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Required")]
        [Display(Name = "UserName")]
        [MinLength(5,ErrorMessage = "UserNameMinLenght5"),MaxLength(25,ErrorMessage = "UserNameMaxLenght25")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress,ErrorMessage = "EmailValid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Password")]
        [MinLength(7,ErrorMessage = "PasswordMinLenght7"), MaxLength(25,ErrorMessage = "PasswordMaxLenght25")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "ConfirmPassword")]
        [MinLength(7,ErrorMessage = "PasswordMinLenght7"), MaxLength(25,ErrorMessage = "PasswordMaxLenght25")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
