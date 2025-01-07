using Books.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Application
{
    public interface IBooksCatalogDbContext
    {
        DbSet<Book> Books { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}