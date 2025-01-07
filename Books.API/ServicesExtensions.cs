using Carter;

namespace Books.API
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCarter();

            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            app.MapCarter();

            return app;
        }
    }
}