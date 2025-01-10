using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Application.Books.Queries.GetBooks;
using Books.Domain.Models;

namespace Books.Application.Contracts
{
    public interface IBooksRepository
    {
        Task<int> GetBooksTotalAsync(GetBooksQuery query, CancellationToken cancellationToken);
        Task<IEnumerable<Book>> GetBooksAsync(GetBooksQuery query, CancellationToken cancellationToken);
        Task<Book> CreateBookAsync(Book book, CancellationToken cancellationToken);
    }
}
