using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StationManagementSystem.Models;
using StationManagementSystem.Views;

namespace StationManagementSystem.Services
{
    public static class ServiceConfigurator
    {
        // Method to configure services
        public static ServiceProvider ConfigureServices(ServiceCollection services, IConfiguration configuration)
        {

            // Register configuration so it can be injected
            services.AddSingleton<IConfiguration>(configuration);

            // Register ApplicationDbContext with the connection string from config
            services.AddDbContext<StationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Add other services here if needed
            //services.AddTransient<MainForm>();            // Register MainForm for DI
            services.AddTransient<MainForm>();

            //services.AddScoped<CategoryService>();

            // Apply pending migrations at startup
            var serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<StationContext>();
                context.Database.Migrate(); // This applies pending migrations
            }
            return services.BuildServiceProvider();
        }
    }
}
