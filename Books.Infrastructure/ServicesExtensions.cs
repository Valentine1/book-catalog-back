using Books.Application;
using Books.Application.Contracts;
using Books.Infrastructure.Repositories;
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
            services.AddScoped<IBooksRepository, BooksRepository>();

            return services;
        }
    }
}
