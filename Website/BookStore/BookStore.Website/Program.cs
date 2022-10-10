using BookStore.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using System;
using BookStore.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Đăng ký AppDbContext
builder.Services.AddDbContext<AppDatabase>(options => {
    // Đọc chuỗi kết nối
    string connectstring = @"Data Source=DESKTOP-J98APIA;Initial Catalog=BookStore;User ID=sa;Password=Thinhyeuhocbai123";
    // Sử dụng MS SQL Server
    options.UseSqlServer(connectstring);
});

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDatabase>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "Myareas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
     name: "default",
     pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapRazorPages();
});

app.Run();
