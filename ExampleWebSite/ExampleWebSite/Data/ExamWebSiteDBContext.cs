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

        }

        DbSet<PropertiesModel> Properties { get; set; }
        DbSet<CollectionModel> Collections { get; set; }
        DbSet<ItemsModel> Items { get; set; }
        DbSet<LikeModel> Likes { get; set; }
        DbSet<ThemaModel> Themes { get; set; }
    }
}
