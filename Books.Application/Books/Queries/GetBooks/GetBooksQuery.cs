using Books.Application.CQRS;
using Books.Application.Dtos;

namespace Books.Application.Books.Queries.GetBooks
{
    public record GetBooksQuery() : IQuery<GetBooksResult>;

    public record GetBooksResult(IEnumerable<BookDto> Books);
}