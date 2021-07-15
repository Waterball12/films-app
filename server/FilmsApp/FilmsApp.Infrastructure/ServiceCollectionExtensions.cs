using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsApp.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<FilmContext>(cf =>
            {
                cf.UseInMemoryDatabase("film");
            });

            return services;
        }
    }
}
