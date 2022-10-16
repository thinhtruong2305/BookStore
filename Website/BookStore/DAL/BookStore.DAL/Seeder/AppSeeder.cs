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

            Book book = new Book
            {
                Title = "Over lord",
                Keyword = "Over lord",
                Decription = "Chuyện kể về một thanh niên được chuyển sinh thành một nhân vật của mình trong game",
                Slug = "over-lord",
                CreateBy = "admin",
                CreateAt = DateTime.Now,
                Status = Common.Shared.Model.Status.Active,
                Info = new Info
                {
                    DiscountPercent = 20,
                    Language = "Việt Nam",
                    VolumeNumber = 14,
                    CreateBy = "admin",
                    CreateAt = DateTime.Now,
                    Status = Common.Shared.Model.Status.Active,
                    Series = new Series
                    {
                        SeriesName = "Over lord",
                        PlannedVolume = 14,
                        CreateBy = "admin",
                        CreateAt = DateTime.Now
                    }
                },
                Edition = new Edition
                {
                    ISBN = "12342351",
                    Price = 20000,
                    Pages = 80,
                    PrintRunSize = "20.3 x 25.5 cm",
                    Format = "Bìa cứng",
                    Status = Common.Shared.Model.Status.Active,
                    CreateBy = "admin",
                    CreateAt = DateTime.Now,
                }
            };

            database.Add(book);

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
                    FirstName = "Tiến Thịnh",
                    LastName = "Trương Văn",
                    Email = "admin@email.com",
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
                    FirstName = "Trường",
                    LastName = "Phan Nhựt",
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
