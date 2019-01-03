using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.EntityFramework;
using OrderManagement.Core.UserManagement;
using System.Linq;

namespace OrderManagement.Application.Seed
{
    public class SeedDatabaseService
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            // Default User

            var context = serviceProvider.GetRequiredService<OrderManagementDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser
                {
                    Email = "admin@company.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "admin",
                    
                };
                userManager.CreateAsync(user, "admin");
            }
        }
    }
}
