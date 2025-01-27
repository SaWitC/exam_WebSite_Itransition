﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ExampleWebSite.Models
{
    public class User:IdentityUser
    {
        public string ThemeCode { get; set; } = "white";
        public string CultureCode { get; set; } = "ru";
        public IEnumerable<LikeModel> UserLikes { get; set; }
        public IEnumerable<CollectionModel> Collections { get; set; }
        public bool IsBaned { get; set; } = false;
    }
}
