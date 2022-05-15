using ExampleWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Data.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<User> TakeMoreUsers(int size, int page, string UserName, string FinderName);
        public Task BanUsersAsync(IEnumerable<string> UsersNames);
        //public Task BanUserAsync(string UsersNames);
        //public Task BanUserAsync(User user);
        //public Task UnblockUserAsunc(string UserName);
        //public Task UnblockUserAsunc(User user);
        public Task EditThemaAsync(string UserName, string Thema);
        public Task EditCultureAsync(string UserName, string cultureCode);
        public Task<bool> GiveRole(string UserName, string Role);
        public Task<bool> RemoveRoleFromUser(string UserName, string Role);

    }
}
