using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Books.Application.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}