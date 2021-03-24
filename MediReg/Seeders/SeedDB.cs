using System;
using Common.Enums;
using DAL.EF;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API.Seeders
{
    public static class SeedDB
    {
        public static IHost Seed(this IHost webHost)
        {
            using (IServiceScope scope = webHost.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<IAppDbContext>();
                AddRoles(scope.ServiceProvider);
                context.SaveChangesAsync();
                AddUsers(scope.ServiceProvider);
                context.SaveChangesAsync();
            }
            return webHost;
        }

        public static void AddUsers(IServiceProvider serviceProvider)
        {
            using (var userManager = serviceProvider.GetRequiredService<UserManager<User>>())
            {
                var user = new User
                {
                    UserName = "Admin",
                    FirstName = "U.",
                    LastName = "A."
                };
                if(userManager.FindByNameAsync(user.UserName).GetAwaiter().GetResult() == null)
                {
                    userManager.CreateAsync(user, "bekitai").GetAwaiter().GetResult();
                    userManager.AddToRoleAsync(user, RoleType.Admin.ToString());
                }
            }
        }

        public static void AddRoles(IServiceProvider serviceProvider)
        {
            using (var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>())
            {
                foreach (var role in Enum.GetValues(typeof(RoleType)))
                {
                    var normalizedRole = role.ToString().Normalize();
                    if (!roleManager.RoleExistsAsync(normalizedRole).GetAwaiter().GetResult())
                    {
                        roleManager.CreateAsync(new Role { Name = normalizedRole });
                    }
                }
            }
        }
    }
}
