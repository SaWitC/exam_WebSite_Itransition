using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.ViewModels.Account
{
    public class ChangePasswordNonAuthoriseVM
    {
        [Required(ErrorMessage = "Required")]
        [Display(Name = "NewPass")]
        [DataType(DataType.Password)]
        [MinLength(7, ErrorMessage = "PasswordMinLenght7"), MaxLength(25, ErrorMessage = "PasswordMaxLenght25")]
        public string NewPass { get; set; }
        [Required(ErrorMessage = "Required")]
        [Compare("NewPass", ErrorMessage = "PasswordNotCompare")]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        [MinLength(7, ErrorMessage = "PasswordMinLenght7"), MaxLength(25, ErrorMessage = "PasswordMaxLenght25")]
        public string NewPassConfirm { get; set; }

        public string userId { get; set; }
    }
}
