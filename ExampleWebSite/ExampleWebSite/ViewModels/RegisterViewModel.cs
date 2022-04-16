using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(5),MaxLength(25)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MinLength(7), MaxLength(25)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MinLength(7), MaxLength(25)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
