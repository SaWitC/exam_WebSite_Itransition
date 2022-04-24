using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Required")]
        [Display(Name = "UserName")]
        [MinLength(5,ErrorMessage = "UserNameMinLenght5"),MaxLength(25,ErrorMessage = "UserNameMaxLenght25")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name ="Password")]
        [MinLength(7,ErrorMessage = "PasswordMinLenght7"), MaxLength(25,ErrorMessage = "PasswordMaxLenght25")]
        public string Password { get; set; }
        public string ReturnURL { get; set; }
        [Display(Name ="RememberMe")]
        public bool RememberMe { get; set; }
        
    }
}
