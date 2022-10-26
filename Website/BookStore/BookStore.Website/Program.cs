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
using BookStore.Logic;
using Newtonsoft.Json;
using BookStore.Utils.Extension;
using BookStore.Logic.Command.Request;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(option => option.JsonSerializerOptions.PropertyNamingPolicy = null)
    .AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddRazorPages();

//Authenticate
builder.Services.AddCookiesAuthenticate(builder.Configuration);

// Đăng ký AppDbContext
builder.Services.AddSqlDatabase<AppDatabase>(builder.Configuration.GetConnectionString("Database"));

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

//MediatR
builder.Services.AddMediatR(typeof(LoginRequest).Assembly);

builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

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
