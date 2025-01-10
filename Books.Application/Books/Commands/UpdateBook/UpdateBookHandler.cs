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
using Microsoft.EntityFrameworkCore;

namespace Books.Application.Books.Commands.UpdateBook
{
    public class UpdateBookHandler(IBooksRepository _booksRepository)
    : ICommandHandler<UpdateBookCommand, UpdateBookResult>
    {
        public async Task<UpdateBookResult> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var bookId = BookId.Of(command.Book.Id);

            var book = await _booksRepository.GetBookByIdAsync(bookId, cancellationToken);

            if (book is null)
            {
                new UpdateBookResult(false);
            }

            UpdateBook(book, command.Book);

            var result = await _booksRepository.UpdateBookAsync(book, cancellationToken);

            return new UpdateBookResult(true);
        }

        private void UpdateBook(Book book, BookDto bookDto)
        {
            book.Update(bookDto.Title, bookDto.Author, bookDto.Genre);
        }
    }
}
