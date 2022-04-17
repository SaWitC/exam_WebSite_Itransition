using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleWebSite.Models;

namespace ExampleWebSite.Data
{
    public class SampleDate
    {
        public static void InitialiseThemes(ExamWebSiteDBContext _context)
        {
            _context.Themes.AddRange(
                new ThemaModel {Id=1,Title ="Books",Description="coloctions of books"},
                new ThemaModel { Id = 2, Title = "Minerals", Description = "coloctions of Minerals" },
                new ThemaModel { Id = 3, Title = "alcohol", Description = "coloctions of alcohol" }
                );
            _context.SaveChangesAsync();
        }
    }
}
