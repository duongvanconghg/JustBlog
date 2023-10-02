using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Repository.UoW;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<JustBlogContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("JustBlogContext")));
builder.Services.AddScoped<IUoW, UoW>();

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

app.MapControllerRoute(
    name: "Post",
    pattern: "Posts/{year}/{month}/{title}",
    defaults: new { controller = "Posts", action = "Details" },
    constraints: new { year = @"\d{4}", month = @"\d{2}" });

app.MapControllerRoute(
    name: "Category",
    pattern: "Categories/{name}",
    defaults: new { controller = "Categories", action = "Details" });

app.MapControllerRoute(
    name: "Tag",
    pattern: "Tags/{name}",
    defaults: new { controller = "Tags", action = "Details" });

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
