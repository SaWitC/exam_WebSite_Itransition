using ExampleWebSite.Data.ConfigurationModels;
using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models;
using ExampleWebSite.ResourcesModels;
using ExampleWebSite.ViewModels;
using ExampleWebSite.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExampleWebSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserRepository _userRepository;
        private readonly IStringLocalizer<ResourcesToControllerModel> _stringLocalizer;
        private readonly IOptions<AdminAccountDataModel> _options;
        private readonly IOptions<AppConfigDataModel> _AppConfigData;


        private static int UserSize;//size of Users
        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IUserRepository userRepository,
            IStringLocalizer<ResourcesToControllerModel> stringLocalizer,
            IOptions<AdminAccountDataModel> options,
            IOptions<AppConfigDataModel> AppConfigData)
        {
            _options = options;
            _stringLocalizer = stringLocalizer;
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _AppConfigData = AppConfigData;

            UserSize = int.Parse(_AppConfigData.Value.UserSize);
        }

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
                User user = new User{ Email = model.Email, UserName = model.UserName };
                var resoult = await _userManager.CreateAsync(user, model.Password);
                if (resoult.Succeeded)
                {
                    await _userManager.AddClaimAsync(user, new Claim("IsBaned", user.IsBaned.ToString())); ;

                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction("Index", "Collection");
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
        [HttpGet]
        public IActionResult Login(string returnURL)
        {
            return View(new LoginViewModel { ReturnURL = returnURL });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    if (user.IsBaned) return RedirectToAction("YourAccountIsBaned","Account");

                    var result
                       = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider
                            .MakeCookieValue(new RequestCulture(user.CultureCode, user.CultureCode)));
                        // check Url
                        if (!string.IsNullOrEmpty(model.ReturnURL) && Url.IsLocalUrl(model.ReturnURL))
                        {
                            return Redirect(model.ReturnURL);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Collection");
                        }
                    }
                }
            }
            else
            {
                ModelState.AddModelError("",_stringLocalizer["BadPassworOrEmail"]);
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        #region OnlyAuthorize
        [Authorize]
        [HttpGet]
        public IActionResult ChangePasswordAuthorise()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePasswordAuthorise(ChangePasswordAuthoriseVM model)
        {
            if (model.name == null)
            {

            }
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.name);
                if (user != null)
                {
                    IdentityResult result = await _userManager.ChangePasswordAsync(user, model.oldPass, model.NewPass);
                    if (result.Succeeded)
                    {
                        await _userManager.UpdateAsync(user);
                        return RedirectToAction(nameof(Index));//changedMessge
                    }
                }
                else
                {
                    return RedirectToAction("Error");
                }

            }
            ModelState.AddModelError("", "не верный пароль");
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult EditPhone()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditPhone(EditPhoneViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.PhoneNumber = model.PhoneNumber;
                IdentityResult resoult = await _userManager.UpdateAsync(user);
                if (resoult.Succeeded)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "что-то пошло не так");
                }

            }
            return View(model);
        }


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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditCultre(User user, string cultureCode)
        {
            await _userRepository.EditCultureAsync(User.Identity.Name, cultureCode);
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider
                .MakeCookieValue(new RequestCulture(user.CultureCode, user.CultureCode)));

            return RedirectToAction("PersonalData", "Account");
        }

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
        #endregion
        #region Admin
        [HttpGet]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> OperationsWithUser(string UserName)
        {
            if (String.IsNullOrEmpty(UserName)) return NotFound();
            InformationAboutUser model = new InformationAboutUser();
            var user = await _userManager.FindByNameAsync(UserName);
            if (user != null)
            {
                model.user = user;
                model.roles = await _userManager.GetRolesAsync(user);
                return View(model);
            }
            else
                return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> CheckInfoAboutUser(string UserName)
        {
            InformationAboutUser model = new InformationAboutUser();
            var user = await _userManager.FindByNameAsync(UserName);
            if (user != null)
            {
                model.user = user;
                model.roles =await _userManager.GetRolesAsync(user);
                return View(model);
            }
            else
                return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult AdminPage()
        {
            return View();
        }
        [Authorize(Roles ="admin")]
        [HttpGet]
        public IActionResult FindUsersByName(string SearchString,int page=0)
        {
            var model = new FindUserViewModel();
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
            {
                model.Users = _userRepository.TakeMoreUsers(UserSize, page, SearchString, User.Identity.Name);
                return PartialView("_WriteMoreUsers",model);
            }
            model.Users = _userRepository.TakeMoreUsers(UserSize, 0, SearchString, User.Identity.Name);
            return View(model);
        }

        public IActionResult _WriteMoreUsers()
        {
            return PartialView();
        }
        //ban ============================================================================
        //[HttpPost]
        //[Authorize(Roles ="admin")]
        //public async Task<IActionResult> Ban(FindUserViewModel model,string User)
        //{
        //    if (User != null)
        //    {
        //        await _userRepository.BanUserAsync(User);
        //    }
        //    if (model != null)
        //        return RedirectToAction("FindUsersByName", "Account",model);
        //    else
        //        return Ok();
        //}

        //[HttpPost]
        //[Authorize(Roles = "admin")]
        //public async Task<IActionResult> UnBan(FindUserViewModel model, string User)
        //{
        //    if (User != null)
        //    {
        //        await _userRepository.UnblockUserAsunc(User);
        //    }
        //    return RedirectToAction("FindUsersByName", "Account", model);
        //}

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Ban(string UserName)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            if (user != null)
            {

                await _userRepository.BanUserAsync(user);

                var Claims = await _userManager.GetClaimsAsync(user);
                var IsBanedClaim = Claims.FirstOrDefault(o => o.Type == "IsBaned");
                if (IsBanedClaim != null)
                {
                    await _userManager.RemoveClaimAsync(user, IsBanedClaim);
                    await _userManager.AddClaimAsync(user, new Claim("IsBaned", true.ToString()));
                }
            }
            return RedirectToAction("OperationsWithUser","Account",new { UserName = user.UserName});
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UnBan(string UserName)
        {
            var user = await _userManager.FindByNameAsync(UserName);

            if (user != null)
            {
                await _userRepository.UnblockUserAsunc(user);

                var Claims = await _userManager.GetClaimsAsync(user);
                var IsBanedClaim = Claims.FirstOrDefault(o => o.Type == "IsBaned");
                if (IsBanedClaim != null)
                {
                    await _userManager.RemoveClaimAsync(user, IsBanedClaim);
                    await _userManager.AddClaimAsync(user, new Claim("IsBaned", false.ToString()));
                }
            }
            return RedirectToAction("OperationsWithUser","Account",new { UserName = user.UserName});
        }

        [HttpPost]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> GiveRole(string UserName,string RoleName)
        {
            var result = await _userRepository.GiveRole(UserName, RoleName);
            if (result)
                return RedirectToAction("OperationsWithUser", "Account", new { UserName = UserName });
            else
                return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RemoveRole(string UserName,string RoleName)
        {
            var user = _options.Value.AdminAccountEmail;
            if (user != UserName)
            {
                var result = await _userRepository.RemoveRoleFromUser(UserName, RoleName);
                if (result)
                    return RedirectToAction("OperationsWithUser", "Account", new { UserName = UserName });
            }
                return NotFound();
        }
        #endregion
        private async Task Authenticate(User user)////////////////////////////////////////////////////////////////
        {
            var claims = new List<Claim>
            {
                new Claim("Isbaned", user.IsBaned.ToString()),
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // set autenticate cockies
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
