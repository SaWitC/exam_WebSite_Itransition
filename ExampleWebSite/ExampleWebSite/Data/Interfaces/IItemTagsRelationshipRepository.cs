using ExampleWebSite.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebSite.Data.Interfaces
{
    public interface IItemTagsrelationshipRepository
    {
        public Task CreateAsync(ItemModel Item,IEnumerable<TagModel> Tags);
        public Task<IEnumerable<ItemTagsrelationshipspModel>> GetRelationshipsByItemIdAsync(int Id);

    }
}
