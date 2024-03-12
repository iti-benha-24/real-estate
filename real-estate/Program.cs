using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using real_estate.Models;
using real_estate.Repos;
namespace real_estate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           
            builder.Services.AddDbContext<real_estateDB>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constr")));

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<real_estateDB>();
            builder.Services.AddScoped<PropertyRepo>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
         
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

            app.MapRazorPages();
            app.Run();
        }
    }
}
