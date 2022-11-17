using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Utils.Extension
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddSqlDatabase<TContext>(this IServiceCollection services,
            string connectionString)
            where TContext : DbContext
        {
            services.AddDbContext<TContext>(options =>
            {
                options.UseSqlServer(connectionString, c =>
                {
                    c.CommandTimeout(1000);
                    c.EnableRetryOnFailure(5);
                    c.MigrationsAssembly("BookStore.DAL");
                });
            });
            return services;
        }

        public static IServiceCollection AddCookiesAuthenticate(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, option =>
                {
                    option.AccessDeniedPath = "/AccessDenied";
                    option.LogoutPath = "/Logout/";
                    option.LoginPath = "/Login/";
                });
            return services;
        }

        public static IServiceCollection AddExternalAuth(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication()
                .AddFacebook(faceBookOption =>
                {
                    faceBookOption.AppId = configuration["Authentication:FaceBook:AppId"];
                    faceBookOption.AppSecret = configuration["Authentication:FaceBook:AppSecret"];
                    faceBookOption.AccessDeniedPath = configuration["Authentication:FaceBook:AccessDeniedPath"];
                })
                .AddGoogle(googleOption =>
                {
                    googleOption.ClientId = configuration["Authentication:Google:ClientId"];
                    googleOption.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                });
            return services;
        }
        public static IServiceCollection AddIdentityConfig<TUser, TRole, TDbContext>(this IServiceCollection services)
            where TUser : IdentityUser
            where TRole : IdentityRole
            where TDbContext : DbContext
        {
            services.AddIdentity<TUser, TRole>()
                .AddEntityFrameworkStores<TDbContext>()
                .AddDefaultTokenProviders()
                .AddSignInManager();

            services.Configure<IdentityOptions>(option =>
            {
                // Thiết lập về Password
                option.Password.RequireDigit = false; // Không bắt phải có số
                option.Password.RequireLowercase = false; // Không bắt phải có chữ thường
                option.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
                option.Password.RequireUppercase = false; // Không bắt buộc chữ in
                option.Password.RequiredLength = 3; // Số ký tự tối thiểu của password

                // Cấu hình Lockout - khóa user
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
                option.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
                option.Lockout.AllowedForNewUsers = true;

                // Cấu hình về User.
                option.User.AllowedUserNameCharacters = // các ký tự đặt tên user
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                option.User.RequireUniqueEmail = true;  // Email là duy nhất

                // Cấu hình đăng nhập.
                option.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                option.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại
                option.SignIn.RequireConfirmedAccount = true;
            });
            return services;
        }
    }
}
