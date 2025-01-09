using Books.Application.Contracts;
using Books.Application.CQRS;
using Books.Application.Extensions;

namespace Books.Application.Books.Queries.GetBooks
{
    public class GetBookssHandler(IBooksRepository _booksRepository)
        : IQueryHandler<GetBooksQuery, GetBooksResult>
    {
        public async Task<GetBooksResult> Handle(GetBooksQuery query, CancellationToken cancellationToken)
        {
            var total = await _booksRepository.GetBooksTotalAsync(cancellationToken);

            var books = await _booksRepository.GetBooksAsync(query, cancellationToken);

            var result =  new GetBooksResult(books.ToBookDtos(), total);
            return result;
        }
    }
}
