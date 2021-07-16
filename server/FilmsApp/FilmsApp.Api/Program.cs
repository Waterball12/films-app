using FilmsApp.Infrastructure;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace FilmsApp.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args);

            using var scope = host.Services.CreateScope();

            var context = scope.ServiceProvider.GetService<FilmContext>();

            // Create a Seed for the film context
            // So that we have some data to work on
            var seed = new FilmContextSeed();

            await seed.SeedAsync(context);

            host.Run();
        }

        public static IWebHost CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

    }
}
