using System.Reflection;
using Books.Application.CQRS;
using Books.Application.Dtos;

namespace Books.Application.Books.Queries.GetBooks
{
    public record GetBooksQuery(string? TitleSearch,
        string? AuthorSearch,
        string? GenreSearch,
        string OrderBy = "title",
        bool IsAscending = true,
        int PageIndex = 0,
        int PageSize = 4) : IQuery<GetBooksResult>;

    public record GetBooksResult(IEnumerable<BookDto> Books,
        int TotalCount);
}