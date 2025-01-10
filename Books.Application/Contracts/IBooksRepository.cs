using Books.Application.Books.Queries.GetBooks;
using Books.Domain.Models;
using Books.Domain.ValueObjects;

namespace Books.Application.Contracts
{
    public interface IBooksRepository
    {
        Task<int> GetBooksTotalAsync(GetBooksQuery query, CancellationToken cancellationToken);
        Task<IEnumerable<Book>> GetBooksAsync(GetBooksQuery query, CancellationToken cancellationToken);
        Task<Book> CreateBookAsync(Book book, CancellationToken cancellationToken);
        Task<Book?> GetBookByIdAsync(BookId bookId, CancellationToken cancellationToken);
        Task<bool> UpdateBookAsync(Book book, CancellationToken cancellationToken);
    }
}