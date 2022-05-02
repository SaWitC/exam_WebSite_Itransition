using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models;
using ExampleWebSite.ViewModels;
using ExampleWebSite.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserRepository _userRepository;

        private int size = 10;//size of Users
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //register ===================================================================
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User() { Email = model.Email, UserName = model.UserName };//initialise object
                var resoult = await _userManager.CreateAsync(user, model.Password);//crete new user
                if (resoult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);//add cockies
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var x in resoult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, x.Description);
                    }
                }
            }
            return View();
        }
        //login ==============================================================
        [HttpGet]
        public IActionResult Login(string returnURL)
        {
            return View(new LoginViewModel { ReturnURL = returnURL });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Response.Cookies.Append("name", "Tom");
            if (ModelState.IsValid)
            {
                var result
                   = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,CookieRequestCultureProvider
                        .MakeCookieValue(new RequestCulture(user.CultureCode,user.CultureCode)));

                    // check Url
                    if (!string.IsNullOrEmpty(model.ReturnURL) && Url.IsLocalUrl(model.ReturnURL))
                    {
                        return Redirect(model.ReturnURL);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            //else
            //{
            //    ModelState.AddModelError("", "Неправильный логин и (или) пароль");//Res
            //}
            return View(model);
        }
        //logout =============================================================
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        // other Pages =======================================================
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }
        [Authorize]
        public async Task<IActionResult> PersonalData()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }

        //editThame ==================================================================
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditThemeModal()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return PartialView(user);

        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditThemeModal(string Thema)
        {
            await _userRepository.EditThemaAsync(User.Identity.Name, Thema);
            return RedirectToAction("PersonalData", "Account");
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        //adminPage ==================================================================
        public IActionResult AdminPage()
        {
            return View();
        }

        //Find ==========================================================================
        [Authorize(Roles ="admin")]
        [HttpGet]
        public IActionResult FindUsersByName(string SearchString,int page=0)
        {
            var model = new FindUserViewModel();
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
            {
                model.Users = _userRepository.TakeMoreUsers(size, page, SearchString, User.Identity.Name);
                return PartialView("_WriteMoreUsers",model);
            }
            model.Users = _userRepository.TakeMoreUsers(size, 0, SearchString, User.Identity.Name);
            return View(model);
        }

        public IActionResult _WriteMoreUsers()
        {
            return PartialView();
        }
        //ban ============================================================================
        [HttpPost]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Ban(FindUserViewModel model,string User)
        {
            if (User != null)
            {
                await _userRepository.BanUserAsync(User);
            }
            return RedirectToAction("FindUsersByName", "Account",model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UnBan(FindUserViewModel model, string User)
        {
            if (User != null)
            {
                await _userRepository.UnblockUserAsunc(User);
            }
            return RedirectToAction("FindUsersByName", "Account", model);
        }
        //EditCulture ==============================================================
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditCultre(User user,string cultureCode)
        {
            await _userRepository.EditCultureAsync(User.Identity.Name,cultureCode);
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider
                .MakeCookieValue(new RequestCulture(user.CultureCode, user.CultureCode)));

            return RedirectToAction("PersonalData", "Account");
        }
    }
}
