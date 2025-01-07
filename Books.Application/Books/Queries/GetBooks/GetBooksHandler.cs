using Books.Application.CQRS;
using Books.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Books.Application.Books.Queries.GetBooks
{
    public class GetBookssHandler(IBooksCatalogDbContext dbContext)
        : IQueryHandler<GetBooksQuery, GetBooksResult>
    {
        public async Task<GetBooksResult> Handle(GetBooksQuery query, CancellationToken cancellationToken)
        {

            var totalCount = await dbContext.Books.LongCountAsync(cancellationToken);

            var books = await dbContext.Books
                           .ToListAsync(cancellationToken);

            return new GetBooksResult(books.ToBookDtos());
        }
    }
}
