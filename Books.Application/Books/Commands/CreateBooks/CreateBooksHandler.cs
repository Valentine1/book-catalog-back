using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Application.Books.Commands.CreateBook;
using Books.Application.Contracts;
using Books.Application.CQRS;
using Books.Application.Dtos;
using Books.Domain.Models;
using Books.Domain.ValueObjects;

namespace Books.Application.Books.Commands.CreateBooks
{
    public class CreateBooksHandler(IBooksRepository _booksRepository)
        : ICommandHandler<CreateBooksCommand, CreateBooksResult>
    {
        public async Task<CreateBooksResult> Handle(CreateBooksCommand command, CancellationToken cancellationToken)
        {
            var books = CreateNewBooks(command.Books);
            await _booksRepository.CreateBooksAsync(books, cancellationToken);

            return new CreateBooksResult(books.Select(b => b.Id.Value).ToList());
        }

        private List<Book> CreateNewBooks(List<BookDto> books)
        {
            return books.Select(b => Book.Create(b.Title, b.Author, b.Genre)).ToList();
        }
    }
}
