using Books.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Books.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            services.AddDbContext<BooksCatalogDbContext>((sp, options) =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IBooksCatalogDbContext, BooksCatalogDbContext>();

            return services;
        }
    }
}
