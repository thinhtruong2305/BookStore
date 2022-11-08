using BookStore.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Seeder
{
    public class AppSeeder
    {
        public static async Task InitializeAsync(AppDatabase database,
            UserManager<User> user, RoleManager<IdentityRole> role)
        {
            database.Database.EnsureCreated();

            if (!role.Roles.Any())
            {
                await role.CreateAsync(new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });
                await role.CreateAsync(new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "USER"
                });
            }

            if (!user.Users.Any())
            {
                var createAdminResult = await user.CreateAsync(new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "admin",
                    Address = "123 blabla Ambatukam, P.Ambasing, Q.Shiba",
                    DateOfBirth = new DateTime(2005, 05, 12),
                    FirstName = "Trương Văn Tiến",
                    LastName = "Thịnh",
                    Email = "admin@email.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                }, "Admin@123");

                if (createAdminResult.Succeeded)
                {
                    var userResult = await user.FindByNameAsync("admin");
                    await user.AddToRoleAsync(userResult, "Admin");
                }

                var createUserResult = await user.CreateAsync(new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "user",
                    Email = "user@email.com",
                    Address = "123 blabla Ambatukam, P.Ambasing, Q.Shiba",
                    DateOfBirth = new DateTime(2002, 05, 12),
                    FirstName = "Võ Thị Lan",
                    LastName = "Anh",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                }, "User@123");

                if (createUserResult.Succeeded)
                {
                    var userResult = await user.FindByNameAsync("user");
                    await user.AddToRoleAsync(userResult, "User");
                }
            }
        }
    }
}
