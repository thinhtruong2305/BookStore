using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
                .AddCookie(option =>
                {
                    option.ExpireTimeSpan = TimeSpan.FromMinutes(double.Parse(configuration.GetSection("AuthCookies: TimeOut").Value));
                    option.SlidingExpiration = true;
                    option.AccessDeniedPath = "/Forbiden";
                    option.LoginPath = configuration.GetSection("AuthCookies: LoginPath").Value;
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
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 1;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;
            });
            return services;
        }
    }
}
