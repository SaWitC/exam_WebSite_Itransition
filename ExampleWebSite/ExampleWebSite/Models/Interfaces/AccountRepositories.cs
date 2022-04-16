using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.ViewModels;

namespace ExampleWebSite.Models.Interfaces
{
    public interface AccountRepositories
    {
        public IActionResult Register();
        public Task<IActionResult> Register(RegisterViewModel model);

        public IActionResult Login();
        public Task<IActionResult> Login(LoginViewModel model);

        public Task Logout();

    }
}
