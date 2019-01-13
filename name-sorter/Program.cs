using Microsoft.Extensions.DependencyInjection;

namespace NameSorter.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = StartUp.SetupConfigFile();

            var serviceCollection = new ServiceCollection();
            StartUp.ConfigureDependencies(serviceCollection, config);

            // Build the our IServiceProvider and set our static reference to it
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Run the application
            serviceProvider.GetService<INameSorterApplication>().Run(args);
        }

        
    }
}
