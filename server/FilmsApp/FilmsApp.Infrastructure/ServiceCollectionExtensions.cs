using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsApp.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add data access to services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
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
