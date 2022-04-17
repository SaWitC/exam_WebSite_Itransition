using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Models;

namespace ExampleWebSite.Data.Interfaces
{
    public interface IThemeRepository
    {
        public IEnumerable<ThemaModel> TakeAll();
        public Task<IEnumerable<ThemaModel>> TakeAllAsync();
        public ThemaModel FindById(int id);
        public Task<ThemaModel> FindByIdASync(int id);

        public ThemaModel FindByTitle(string title);
        public Task<ThemaModel> FindByTitleAsync(string title);


    }
}
