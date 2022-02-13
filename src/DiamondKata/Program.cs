using DiamondKata;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = ConfigureServices();
        var diamond = serviceProvider.GetService<IDiamond>();

        while (true)
        {
            Console.WriteLine("Please, enter a letter:");

            var input = Console.ReadLine();
            var output = diamond.Create(input);

            Console.WriteLine(output);
        }
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddScoped<IDiamond, Diamond>();

        return services.BuildServiceProvider();
    }
}
