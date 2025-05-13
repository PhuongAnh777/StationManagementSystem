
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StationManagementSystem.Services;
using StationManagementSystem.Views;

namespace StationManagementSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static IServiceProvider ServiceProvider { get; private set; } = null;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Load configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            var services = new ServiceCollection();

            // Configure services and get the service provider
            ServiceProvider = ServiceConfigurator.ConfigureServices(services, configuration);

            // Resolve MainForm through DI
            //var mainForm = ServiceProvider.GetRequiredService<MainForm>();
            var login = ServiceProvider.GetRequiredService<LoginForm>();
            // Run application
            //Application.Run(mainForm);
            //Application.Run(new Sell());
            Application.Run(login);
        }
    }
}