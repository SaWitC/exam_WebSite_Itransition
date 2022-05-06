using ExampleWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.ViewModels.Account
{
    public class InformationAboutUser
    {
        public User user { get; set; }
        public IEnumerable<string> roles { get; set; }
    }
}
