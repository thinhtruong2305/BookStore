using BookStore.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using System;
using BookStore.DAL;
using BookStore.Logic;
using Microsoft.EntityFrameworkCore;
using BookStore.DAL.Seeder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NuGet.Protocol.Plugins;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using MediatR;
using BookStore.Logic.MappingProfile;
using Newtonsoft.Json;
using BookStore.Utils.Extension;
using BookStore.Logic.Command.Request;
using Microsoft.AspNetCore.Identity.UI.Services;
using BookStore.Common.Shared.Config;
using BookStore.Logic.Shared.Catalog.Interface;
using BookStore.Logic.Shared.Catalog.Implement;
using Microsoft.CodeAnalysis.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using BookStore.Website.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using BookStore.Website.Areas.Admin.Models.MappingProfile;
using Microsoft.AspNetCore.Routing.Template;
using BookStore.Website.Models.MappingProfile;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(option => option.JsonSerializerOptions.PropertyNamingPolicy = null)
    .AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddRazorPages();

//Send mail
builder.Services.Configure<MailConfig>(builder.Configuration.GetSection("MailSettings"));

// Đăng ký dịch vụ Mail
builder.Services.AddTransient<ISendMailService, SendMailService>();

//Authenticate
builder.Services.AddCookiesAuthenticate(builder.Configuration);

builder.Services.ConfigureApplicationCookie(options => {
    options.Cookie = new CookieBuilder
    {
        //Domain = "",
        HttpOnly = true,
        Name = ".aspNetCoreDemo.Security.Cookie",
        Path = "/",
        SameSite = SameSiteMode.Lax,
        SecurePolicy = CookieSecurePolicy.SameAsRequest
    };
    options.Events = new CookieAuthenticationEvents
    {
        OnSignedIn = context =>
        {
            Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
                "OnSignedIn", context?.Principal?.Identity?.Name);
            return Task.CompletedTask;
        },
        OnSigningOut = context =>
        {
            Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
                "OnSigningOut", context?.HttpContext?.User?.Identity?.Name);
            return Task.CompletedTask;
        },
        OnValidatePrincipal = context =>
        {
            Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
                "OnValidatePrincipal", context?.Principal?.Identity?.Name);
            return Task.CompletedTask;
        }
    };
    options.AccessDeniedPath = "/AccessDenied";
    options.LogoutPath = "/Logout/";
    options.LoginPath = "/Login/";
});

// Đăng ký AppDbContext
builder.Services.AddDbContext<AppDatabase>(option =>
{
    string connectionString = builder.Configuration.GetConnectionString("Database");
    option.UseSqlServer(connectionString, b => b.MigrationsAssembly("BookStore.DAL"));
});

builder.Services.AddDistributedMemoryCache();           // Đăng ký dịch vụ lưu cache trong bộ nhớ (Session sẽ sử dụng nó)
builder.Services.AddSession(cfg => {                    // Đăng ký dịch vụ Session
    cfg.Cookie.Name = "BookStore";             // Đặt tên Session - tên này sử dụng ở Browser (Cookie)
    cfg.IdleTimeout = new TimeSpan(0, 30, 0);    // Thời gian tồn tại của Session
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Identity
builder.Services.AddIdentityConfig<User, IdentityRole, AppDatabase>();

/*builder.Services.AddDbContext<AppDatabase>(options => {
    // Đọc chuỗi kết nối
    string connectstring = @"Data Source=DESKTOP-J98APIA;Initial Catalog=BookStore;User ID=sa;Password=Thinhyeuhocbai123";
    // Sử dụng MS SQL Server
    options.UseSqlServer(connectstring, b => b.MigrationsAssembly("BookStore.DAL"));
});*/

//AutoMapper
builder.Services.AddAutoMapper(typeof(AuthorMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(BookViewMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(OrderDetailSenderMappingProfile).Assembly);

//MediatR
builder.Services.AddMediatR(typeof(LoginRequest).Assembly);

builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));
builder.Services.AddTransient<IFileStorageService, FileStorageService>();
/*builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDatabase>()
    .AddDefaultTokenProviders();*/

builder.Services.AddQueries();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var database = scope.ServiceProvider.GetRequiredService<AppDatabase>();
    await database.Database.MigrateAsync();
    await AppSeeder.InitializeAsync(database, userManager, roleManager);
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "AdminDefaultAreas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
     name: "default",
     pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapRazorPages();
});

app.Run();
