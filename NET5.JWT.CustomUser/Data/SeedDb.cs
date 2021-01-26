using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NET5.JWT.CustomUser.Models;

namespace NET5.JWT.CustomUser.Data
{
    public class SeedDb
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            #region Users
            if (!context.Users.Any())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    context.Users.AddRange(new User() { Id = 1, Name = "Paolo", Surname = "Franzini", Email = "paolo.franzini@3p-ictsoftware.it", Password = "Password1!" });
                    context.Users.AddRange(new User() { Id = 2, Name = "User", Surname = "User", Email = "user@user.it", Password = "Password1!" });
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Users ON");
                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Users OFF");


                    context.Roles.AddRange(new Role() { Id = 1, Description = "Admin" });
                    context.Roles.AddRange(new Role() { Id = 2, Description = "Admin" });
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Roles ON");
                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Roles OFF");

                    context.UserRoles.AddRange(new UserRole() { Id = 1, UserId = 1, RoleId = 1 });
                    context.UserRoles.AddRange(new UserRole() { Id = 2, UserId = 2, RoleId = 2 });
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.UserRoles ON");
                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.UserRoles OFF");



                    transaction.Commit();
                }

            }
            #endregion
        }
    }

}
