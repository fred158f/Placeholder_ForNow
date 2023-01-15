using ADL.Interfaces.db_Specific;
using ADL.Models.db_Models;
using AIL.idh.sql.Contexts;
using AIL.idh.sql.Repositories;
using Microsoft.EntityFrameworkCore;

namespace APL_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            string connectionStringPath = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<DataSourceContext>(options => options.UseSqlServer(connectionStringPath));

            builder.Services.AddTransient<IRepository<MeasurementType>, MeasurementTypeRepository>();
            builder.Services.AddTransient<IRepository<MeasurementSource>, MeasurementSourceRepository>();
            
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
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}