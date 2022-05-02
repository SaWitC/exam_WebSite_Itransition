﻿using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task BanUsersAsync(IEnumerable<string> userNames)
        {
            foreach (var item in userNames)
            {
                var user =await _userManager.FindByNameAsync(item);
                if (user != null)
                {
                    user.IsBaned = true;
                    await _userManager.UpdateAsync(user);
                }
            }
        }

        public async Task BanUserAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                user.IsBaned = true;
                await _userManager.UpdateAsync(user);
            }
        }

        public IEnumerable<User> TakeMoreUsers(int size, int page,string UserName,string FinderName)
        {
            int skip = size * page;
            if (!string.IsNullOrEmpty(UserName))
            {
                return _userManager.Users.Skip(skip).Take(size).Where(o => o.UserName != FinderName&&o.UserName
                .ToLower().Contains(UserName.ToLower()));
            }
            else
            {
                return _userManager.Users.Skip(skip).Take(size).Where(o => o.UserName != FinderName);
            }
        }

        public async Task UnblockUserAsunc(string userName)
        {
            var user =await _userManager.FindByNameAsync(userName);
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

    }
}