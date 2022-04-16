using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ExampleWebSite.Models;

namespace ExampleWebSite.Data
{
    public class ExamWebSiteDBContext:IdentityDbContext<User>
    {
        public ExamWebSiteDBContext(DbContextOptions<ExamWebSiteDBContext> options) : base(options)
        {

        }
    }
}
