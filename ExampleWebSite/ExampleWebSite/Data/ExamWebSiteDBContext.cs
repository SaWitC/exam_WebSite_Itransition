﻿using System;
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

        public DbSet<PropertiesElementModel> Properties { get; set; }
        public DbSet<CollectionModel> Collections { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<LikeModel> Likes { get; set; }
        public DbSet<ThemaModel> Themes { get; set; }
    }
}
