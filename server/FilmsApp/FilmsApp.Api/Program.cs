using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmsApp.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsApp.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args);

            using var scope = host.Services.CreateScope();

            var context = scope.ServiceProvider.GetService<FilmContext>();

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
