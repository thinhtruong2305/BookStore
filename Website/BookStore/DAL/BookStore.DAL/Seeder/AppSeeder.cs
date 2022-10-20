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

            List<Tag> tags = new List<Tag>();
            tags.AddRange(new Tag[]{
                new Tag
                {
                    TagName = "Isekai",
                    Keyword = "Isekai",
                    Decription = "Xuyên không, chuyển sinh thành một con người khác",
                    Slug = "isekai",
                    CreateBy = "admin",
                    CreateAt = DateTime.Now,
                    Status = Common.Shared.Model.Status.Active            
                },
                new Tag
                {
                    TagName = "Hành động",
                    Keyword = "Hành động",
                    Decription = "Đánh nhau, gây sát thương cho nhau",
                    Slug = "hanh-dong",
                    CreateBy = "admin",
                    CreateAt = DateTime.Now,
                    Status = Common.Shared.Model.Status.Active            
                }
            });

            Menu[] menus = new Menu[]
            {
                new Menu
                {
                    MenuName = "Truyện Nhật",
                    Keyword = "Truyện Nhật",
                    Decription = "Đây là những cuốn truyện nhật",
                    Slug = "truyen-nhat",
                    Tags = tags,
                    CreateBy = "admin",
                    CreateAt = DateTime.Now,
                    Status = Common.Shared.Model.Status.Active             
                },
                new Menu
                {
                    MenuName = "Light novel",
                    ParentId = 1,
                    Keyword = "Light novel",
                    Decription = "Đây là những tiểu thuyết nhật",
                    Slug = "light-novel",
                    Tags = tags,
                    CreateBy = "admin",
                    CreateAt = DateTime.Now,
                    Status = Common.Shared.Model.Status.Active,
                }
            };

            AuthorBook[] authorBook = new AuthorBook[]
            {
                new AuthorBook
                {
                    Author = new Author
                    {
                        FirstName = "Maruyama",
                        LastName = "Kugane",
                        DateOfBirth = DateTime.Now,
                        CountryOfResidence = "Nhật Bản",
                        Keyword = "Maruyama Kugane",
                        Decription = "Là một tác giả bí ẩn nhất",
                        Slug = "maruyama-kugane",
                        CreateBy = "admin",
                        CreateAt = DateTime.Now,
                        Status = Common.Shared.Model.Status.Delete,
                    },
                    Book = new Book
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
                            },
                            Tags = tags,
                        },
                        Edition = new Edition
                        {
                            ISBN = "12342351",
                            Price = Convert.ToDecimal(50.000),
                            Pages = 80,
                            PrintRunSize = "20.3 x 25.5 cm",
                            Format = "Bìa cứng",
                            Status = Common.Shared.Model.Status.Active,
                            CreateBy = "admin",
                            CreateAt = DateTime.Now,
                        }
                    }
                },
                new AuthorBook
                {
                    Author = new Author
                    {
                        FirstName = "Susu",
                        LastName = " ",
                        DateOfBirth = DateTime.Now,
                        CountryOfResidence = "Việt Nam",
                        Keyword = "Susu",
                        Decription = "Là một tác giả",
                        Slug = "susu",
                        CreateBy = "admin",
                        CreateAt = DateTime.Now,
                        Status = Common.Shared.Model.Status.Active,
                    },
                    Book = new Book
                    {
                        Title = "Mật ngữ 12 chòm sao",
                        Keyword = "Mật ngữ 12 chòm sao",
                        Decription = "Mật ngữ 12 chòm sao là kênh thông tin đầu tiên và chuyên nghiệp nhất về 12 cung hoàng đạo, tử vi phương Tây tại Việt Nam. hang3f ngày mật ngữ 12 chòm sao cung cấp cho bạn đọc thông tin chính xác, vui nhộn về các vấn đề xung quanh, các mối quan hệ: tính cách, sở thích, ... Mật ngữ 12 chòm sao là 1 trào lưu của giới trẻ Việt Nam",
                        Slug = "mat-ngu-12-chom-sao",
                        CreateBy = "admin",
                        CreateAt = DateTime.Now,
                        Status = Common.Shared.Model.Status.Active,
                        Info = new Info
                        {
                            DiscountPercent = 0,
                            Language = "Việt Nam",
                            VolumeNumber = 1,
                            CreateBy = "admin",
                            CreateAt = DateTime.Now,
                            Status = Common.Shared.Model.Status.Active,
                            Series = new Series
                            {
                                SeriesName = "Mật ngữ 12 chòm sao",
                                PlannedVolume = 2,
                                CreateBy = "admin",
                                CreateAt = DateTime.Now,
                                Status = Common.Shared.Model.Status.Active
                            },
                            Tags = tags,
                        },
                        Edition = new Edition
                        {
                            ISBN = "12342351",
                            Price = Convert.ToDecimal(80.000),
                            Pages = 295,
                            PrintRunSize = "20.3 x 25.5 cm",
                            Format = "Bìa cứng",
                            Status = Common.Shared.Model.Status.Active,
                            CreateBy = "admin",
                            CreateAt = DateTime.Now,
                        }
                    }
                }
            };

            EditionPublisher[] editionPublisher = new EditionPublisher[] 
            {
                new EditionPublisher
                {
                    Publisher = new Publisher
                    {
                        PulishingHouse = "Enterbrain",
                        Country = "Nhật bản",
                        Keyword = "Enterbrain",
                        Decription = "Là một nhà xuất bản và thương hiệu con của Kadokawa",
                        Slug = "enterbrain",
                        CreateBy = "admin",
                        CreateAt= DateTime.Now,
                        Status = Common.Shared.Model.Status.Active
                    },
                    Edition = authorBook[0].Book.Edition
                },
                new EditionPublisher
                {
                    Publisher = new Publisher
                    {
                        PulishingHouse = "Kadokawa",
                        Country = "Nhật bản",
                        Keyword = "Kadokawa",
                        Decription = "Là một nhà xuất bản và thương hiệu lớn trong ngành giải trí Nhật Bản",
                        Slug = "kadokawa",
                        CreateBy = "admin",
                        CreateAt= DateTime.Now,
                        Status = Common.Shared.Model.Status.Active
                    },
                    Edition = authorBook[0].Book.Edition
                },
                new EditionPublisher
                {
                    Publisher = new Publisher
                    {
                        PulishingHouse = "Thế Giới",
                        Country = "Việt Nam",
                        Keyword = "Nhà xuất bản Thế Giới",
                        Decription = "Là một nhà xuất bản và thương hiệu Việt Nam",
                        Slug = "the-gioi",
                        CreateBy = "admin",
                        CreateAt= DateTime.Now,
                        Status = Common.Shared.Model.Status.Active
                    },
                    Edition = authorBook[1].Book.Edition
                }
            };

            database.Tags.AddRange(tags);
            database.Menus.AddRange(menus);
            database.AuthorBooks.AddRange(authorBook);
            database.EditionPublishers.AddRange(editionPublisher);

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
