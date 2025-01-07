using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Books.Infrastructure
{
    public static class DatabaseExtensions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<BooksCatalogDbContext>();

            context.Database.MigrateAsync().GetAwaiter().GetResult();

            await SeedAsync(context);
        }

        private static async Task SeedAsync(BooksCatalogDbContext context)
        {
            if (!await context.Books.AnyAsync())
            {
                await context.Books.AddRangeAsync(SeedData.Books);
                await context.SaveChangesAsync();
            }
        }

    }
}
