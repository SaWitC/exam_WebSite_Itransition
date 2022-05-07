using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ExampleWebSite.Models;
using ExampleWebSite.Models.AddationalProperts;


namespace ExampleWebSite.Data
{
    public class ExamWebSiteDBContext:IdentityDbContext<User>
    {
        public ExamWebSiteDBContext(DbContextOptions<ExamWebSiteDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<PropertiesElementModel> PropertiesElement { get; set; }
        public DbSet<CollectionModel> Collections { get; set; }
        public DbSet<ItemTagsrelationshipspModel> ItemTagsrelationships { get; set; }
        public DbSet<TagModel> Tags { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<LikeModel> Likes { get; set; }
        public DbSet<ThemaModel> Themes { get; set; }
        public DbSet<PropertiesModel> Properties { get; set; }
        public DbSet<CommentModel> Comments { get; set; }

    }
}
