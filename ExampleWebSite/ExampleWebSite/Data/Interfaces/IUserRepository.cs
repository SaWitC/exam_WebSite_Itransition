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
        public Task BanUsersAsync(IEnumerable<string> usersNames);
        public Task BanUserAsync(string usersNames);
        public Task UnblockUserAsunc(string userName);

        public Task EditThemaAsync(string UserName, string Thema);

        public Task EditCultureAsync(string userName, string cultureCode);

    }
}
