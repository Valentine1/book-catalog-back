using System.Reflection;
using Books.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure
{
    public class BooksCatalogDbContext : DbContext
    {
        public BooksCatalogDbContext(DbContextOptions<BooksCatalogDbContext> options)
            : base(options) { }

        public DbSet<Book> Books => Set<Book>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}