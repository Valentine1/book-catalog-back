using Books.Application.Dtos;
using Books.Domain.Models;

namespace Books.Application.Extensions
{
    public static class BookExtensions
    {
        public static IEnumerable<BookDto> ToBookDtos(this IEnumerable<Book> books)
        {
            return books.Select(book => new BookDto(
                Id: book.Id.Value,
                Title: book.Title,
                Author: book.Author,
                Genre: book.Genre
              ));
        }
    }
}