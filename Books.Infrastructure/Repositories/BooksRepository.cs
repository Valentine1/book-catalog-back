using Books.Application.Books.Queries.GetBooks;
using Books.Application.Contracts;
using Books.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure.Repositories
{
    public class BooksRepository(BooksCatalogDbContext _context) : IBooksRepository
    {

        public async Task<int> GetBooksTotalAsync(CancellationToken cancellationToken)
        {
            var totalCount = await _context.Books.CountAsync(cancellationToken);
            return totalCount;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(GetBooksQuery query, CancellationToken cancellationToken)
        {
           
            var books = _context.Books.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.TitleSearch))
            {
                books = books.Where(b => EF.Functions.Like(b.Title, $"{query.TitleSearch}%"));
            }
            if (!string.IsNullOrWhiteSpace(query.AuthorSearch))
            {
                books = books.Where(b => EF.Functions.Like(b.Title, $"{query.AuthorSearch}%"));
            }
            if (!string.IsNullOrWhiteSpace(query.GenreSearch))
            {
                books = books.Where(b => EF.Functions.Like(b.Title, $"{query.GenreSearch}%"));
            }
            var orderBy = query.OrderBy?.ToLower() ?? "title";

            books = orderBy switch
            {
                "title" => query.IsAscending
                    ? books.OrderBy(b => b.Title)
                    : books.OrderByDescending(b => b.Title),
                "author" => query.IsAscending
                    ? books.OrderBy(b => b.Author)
                    : books.OrderByDescending(b => b.Author),
                "genre" => query.IsAscending
                    ? books.OrderBy(b => b.Genre)
                    : books.OrderByDescending(b => b.Genre),
                _ => books.OrderBy(b => b.Title)
            };

            books = books
              .AsNoTracking()
              .Skip(query.PageIndex * query.PageSize)
              .Take(query.PageSize);
            var result = await books.ToListAsync();

            return result;
        }
    }
}
