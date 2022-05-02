using ExampleWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.ViewModels.Account
{
    public class FindUserViewModel
    {
        public IEnumerable<User> Users {get;set;} 
        public string SearchString { get; set; }
    }
}
