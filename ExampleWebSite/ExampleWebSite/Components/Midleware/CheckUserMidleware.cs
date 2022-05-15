using ExampleWebSite.Data;
using ExampleWebSite.Data.Interfaces;
using ExampleWebSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ExampleWebSite.Components.Midleware
{
    public class CheckUserMidleware
    {
        private readonly RequestDelegate _next;
        //private readonly ITagRepository tagRepository; 
        private IServiceProvider _serviceProvider;

        public CheckUserMidleware(RequestDelegate next,IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            User user=null;
            using (var scope = _serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var DbContext = services.GetRequiredService<ExamWebSiteDBContext>();

                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var SigninManager = services.GetRequiredService<SignInManager<User>>();
                    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await AdminAccountInitialise.Initialiser(userManager, rolesManager);

                    user = await userManager.FindByNameAsync(context.User.Identity.Name);

                    if (user != null)
                    {
                        if (user.IsBaned == false)
                        {
                            await _next.Invoke(context);

                        }
                        else
                        {
                            await SigninManager.SignOutAsync();
                            context.Response.Redirect("YourAccountIsBaned");
                        }
                    }

                    //SampleDate.InitialiseThemes(context);//initialse category
                }
                catch (Exception ex)
                {
                    await _next.Invoke(context);
                }
            }

            //var user = scope.ServiceProvider.GetRequiredService<IUser>();
            await _next.Invoke(context);
        }
    }
}
