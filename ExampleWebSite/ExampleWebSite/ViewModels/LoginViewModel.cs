using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(5),MaxLength(25)]
        public string UserName { get; set; }
        [Required]
        [MinLength(7), MaxLength(25)]
        public string Password { get; set; }
        public string ReturnURL { get; set; }

        public bool RememberMe { get; set; }
        
    }
}
