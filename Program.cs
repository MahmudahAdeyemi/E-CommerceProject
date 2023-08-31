using E_Commerce_2.Context;
using E_Commerce_2.Entities;
using E_Commerce_2.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using E_Commerce_2.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using E_Commerce_2.Implementations.Services;
using E_Commerce_2.Interfaces.Repositories;
using E_Commerce_2.Implementations.Repositories;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionstring = builder.Configuration.GetConnectionString("EcommerceConnectionString");
builder.Services.AddDbContext<E_commerceContext>(option => option.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring)));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<E_commerceContext>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
   // .AddEntityFrameworkStores<E_commerceContext>()
   // .AddDefaultTokenProviders();
    //.AddRoleManager<IdentityRole>()
    //.AddUserManager<IdentityUser>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Events.OnRedirectToLogin = (context) =>
        {
            context.Response.StatusCode = 401;
            return Task.CompletedTask;
        };
    }); 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapDefaultControllerRoute();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
