using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using real_estate.Models;
using real_estate.Repos.ContractRepo;
using real_estate.Repos.EmployeeRepo;
using real_estate.Repos.PropertyRepo;
namespace real_estate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           
            builder.Services.AddDbContext<real_estateDB>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constr")));

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<real_estateDB>();
            builder.Services.AddScoped<IPropertyRepo,PropertyRepo>();
            builder.Services.AddScoped<IContractRepo, ContractRepo>();
            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddNewtonsoftJson(x=>x.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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
