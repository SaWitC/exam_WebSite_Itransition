using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.ViewModels.Account
{
    public class EditPhoneViewModel
    {
        [Required(ErrorMessage = "Required")]
        [MaxLength(14,ErrorMessage = "PhoneNumerMaxLen14"), MinLength(6, ErrorMessage = "PhoneNumberMinLen6")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "")]
        // [RegularExpression(@"^\(?([0-9]{1,3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{2,3})[-. ]?([0-9]{2})$", ErrorMessage ="Не корректный номер")]
        public string PhoneNumber { get; set; }
    }
}
