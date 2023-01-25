using Layihe_Task_.DAL;
using Layihe_Task_.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Layihe_Task_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));
            builder.Services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequireLowercase = true;
                opt.Password.RequireDigit = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 3;
                opt.User.AllowedUserNameCharacters = "amsamsaimnx";
                opt.User.RequireUniqueEmail = true;
                opt.Lockout.AllowedForNewUsers = true;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

            var app = builder.Build();
           
           
            app.UseStaticFiles();
           
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
            
            app.MapControllerRoute(
                "Default",
                "{Controller=Home}/{Action=Index}/{id?}"
                );

            app.Run();
        }
    }
}