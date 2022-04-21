using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WorkTime.AuthSerice.Data.Models;

namespace WorkTime.AuthSerice.Data.DatabaseInitialization
{
    /// <summary>
    /// Класс для инициализации начальных данных в базу данных
    /// </summary>
    public static class DatabaseInitializer
    {
        /// <summary>
        /// Инициализация начальных данных в базу данных
        /// </summary>
        /// <param name="scopeServiceProvider">Определяет механизм для извлечения объекта службы,
        /// т. е. объекта, обеспечивающего настраиваемую поддержку для других объектов.</param>
        public static async Task InitAsync(IServiceProvider scopeServiceProvider)
        {
            var userManager = scopeServiceProvider.GetService<UserManager<AppUser>>();
            var roleManager = scopeServiceProvider.GetService<RoleManager<AppRole>>();
            var dbContext = scopeServiceProvider.GetService<ApplicationDbContext>();

            //var result = userManager.CreateAsync(user, "123qwe").GetAwaiter().GetResult();
            //if (result.Succeeded)
            //{
            //    userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Administrator")).GetAwaiter().GetResult();
            //    userManager.AddClaimAsync(user, new Claim(JwtClaimTypes.Scope, "OrdersAPI")).GetAwaiter().GetResult();
            //    userManager.AddClaimAsync(user, new Claim(JwtClaimTypes.Scope, "SwaggerAPI")).GetAwaiter().GetResult();
            //}

            string adminName = "admin";
            string employeeName = "empl";
            if (await roleManager.FindByNameAsync("Administrator") == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Administrator" });

            }
            if (await roleManager.FindByNameAsync("Employee") == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Employee" });
            }
            if (await userManager.FindByNameAsync(adminName) == null)
            {
                var admin = new AppUser
                {
                    UserName = adminName
                };
                IdentityResult result = await userManager.CreateAsync(admin, "123qwe");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Administrator");
                    //userManager.AddClaimAsync(admin, new Claim(JwtClaimTypes.Scope, "SwaggerAPI")).GetAwaiter().GetResult();
                    //userManager.AddClaimAsync(admin, new Claim(ClaimTypes.Role, "Administrator1")).GetAwaiter().GetResult();
                    //userManager.AddClaimAsync(admin, new Claim(JwtClaimTypes.Scope, "OrdersAPI")).GetAwaiter().GetResult();

                }
            }
            if (await userManager.FindByNameAsync(employeeName) == null)
            {
                var employee = new AppUser
                {
                    UserName = employeeName
                };
                IdentityResult result = await userManager.CreateAsync(employee, "123qwe");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(employee, "Employee");
                }

                WorkedTimes workTimes = new WorkedTimes
                {
                    User = employee,
                    StartTime = DateTime.Now
                    // для postgresql если не указывать формат времени в методе Startup.Configure()
                    //StartTime = DateTime.UtcNow
                };
                dbContext.WorkedTimes.Add(workTimes);
                dbContext.SaveChanges();
            }
        }
    }
}