using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestKendoTreeView.Controllers;
using TestKendoTreeView.Models;
using TestKendoTreeView.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CacheService>();

builder.Services.AddMediatR(typeof(NotificationHandler),typeof(NotificationHandler1));
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(NotificationHandler).Assembly);


builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer("Server=127.0.0.1;Database= TestKendoTree;User ID=sa;Password=ho1125!!;Trusted_Connection=False;MultipleActiveResultSets=true"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
