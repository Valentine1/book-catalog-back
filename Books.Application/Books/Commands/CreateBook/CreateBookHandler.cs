using Books.Application.Contracts;
using Books.Application.CQRS;
using Books.Application.Dtos;
using Books.Domain.Models;

namespace Books.Application.Books.Commands.CreateBook
{
    public class CreateBookHandler(IBooksRepository _booksRepository) 
        : ICommandHandler<CreateBookCommand, CreateBookResult>
    {
        public async Task<CreateBookResult> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            Book book = CreateNewBook(command.Book);
            await _booksRepository.CreateBookAsync(book, cancellationToken);

            return new CreateBookResult(book.Id.Value);
        }

        private Book CreateNewBook(BookDto book)
        {
            return Book.Create(book.Title, book.Author, book.Genre);
        }
    }
}
