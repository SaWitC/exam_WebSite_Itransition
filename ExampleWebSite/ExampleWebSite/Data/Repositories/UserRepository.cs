using ExampleWebSite.Data.ConfigurationModels;
using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IOptions<AdminAccountDataModel> _options;

        public UserRepository(UserManager<User> userManager,
            IOptions<AdminAccountDataModel> options)
        {
            _options = options;
            _userManager = userManager;
        }
        private bool CheckUserName(string UserName)
        {
            if (_options.Value.AdminAccountEmail != UserName) return true;
            return false;
        }

        public async Task BanUsersAsync(IEnumerable<string> UserNames)
        {
            foreach (var item in UserNames)
            {
                var user =await _userManager.FindByNameAsync(item);
                if (user != null)
                {
                    user.IsBaned = true;
                    await _userManager.UpdateAsync(user);
                }
            }
        }

        public async Task BanUserAsync(string UserName)
        {
            if (CheckUserName(UserName))
            {
                var user = await _userManager.FindByNameAsync(UserName);
                if (user != null)
                {
                    user.IsBaned = true;
                    await _userManager.UpdateAsync(user);
                }
            }
        }
        public async Task BanUserAsync(User user)
        {
            if (CheckUserName(user.UserName))
            {
                if (user != null)
                {
                    user.IsBaned = true;
                    await _userManager.UpdateAsync(user);
                }
            }
        }

        public IEnumerable<User> TakeMoreUsers(int size, int page,string UserName,string FinderName)
        {
            var admin =_options.Value.AdminAccountEmail;
            int skip = size * page;
            if (!string.IsNullOrEmpty(UserName))
            {
                return _userManager.Users.Skip(skip).Take(size).Where(o => o.UserName != FinderName&&
                o.UserName!=admin&&
                o.UserName.ToLower().Contains(UserName.ToLower()));
            }
            else
            {
                return _userManager.Users.Skip(skip).Take(size).Where(o => o.UserName != FinderName &&
                o.UserName != admin);
            }
        }

        public async Task UnblockUserAsunc(string UserName)
        {
            var user =await _userManager.FindByNameAsync(UserName);
            if (user != null)
            {
                user.IsBaned = false;
                await _userManager.UpdateAsync(user);
            }
        }
        public async Task UnblockUserAsunc(User user)
        {
            if (user != null)
            {
                user.IsBaned = false;
                await _userManager.UpdateAsync(user);
            }
        }

        public async Task EditThemaAsync(string UserName, string Thema)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            if (user != null)
            {
                user.ThemeCode = Thema;
                await _userManager.UpdateAsync(user);
            }
        }

        public async Task EditCultureAsync(string UserName, string cultureCode)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            if (user != null)
            {
                user.CultureCode = cultureCode;
                await _userManager.UpdateAsync(user);   
            }
        }

        public async Task<bool> GiveRole(string UserName, string Role)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            if (user != null)
            {
                var resoult = await _userManager.AddToRoleAsync(user,Role);
                if (resoult.Succeeded) return true;
            }
            return false;
        }

        public async Task<bool> RemoveRoleFromUser(string UserName, string Role)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            if (user != null) 
            {
                var resoult = await _userManager.RemoveFromRoleAsync(user, Role);
                if (resoult.Succeeded) return true;
            }
            return false;
        }
    }
}
