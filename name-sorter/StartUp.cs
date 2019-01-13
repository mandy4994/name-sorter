using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NameSorter.Data;
using NameSorter.UI;
using Serilog;
using System.IO;

namespace NameSorter.App
{
    class StartUp
    {
        /// <summary>
        /// Setup config file
        /// </summary>
        /// <returns>IConfiguration instance</returns>
        public static IConfiguration SetupConfigFile()
        {
            // Setup configuration
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return configBuilder.Build();
        }
        public static void ConfigureDependencies(ServiceCollection services, IConfiguration config)
        {
            // Logging configuration
            ConfigureLogging(config);

            services.AddLogging(builder =>
            {
                builder.AddSerilog();
            });

            services.AddTransient<INameSorterApplication, NameSorterApplication>();
            services.AddSingleton<IFileOperations, FileOperations>();
            services.AddTransient<INameSorter, NameSorter>();
            services.AddSingleton<IScreenWriter, ScreenWriter>();
            services.AddSingleton(typeof(IConfiguration), config);
            services.AddTransient<IValidator, Validator>();
        }

        static void ConfigureLogging(IConfiguration config)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(config["LogFilePath"])
                .CreateLogger();
        }
    }
}
