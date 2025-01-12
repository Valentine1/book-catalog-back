﻿using Books.Application.Books.Queries.GetBooks;
using Books.Application.Contracts;
using Books.Domain.Models;
using Books.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure.Repositories
{
    public class BooksRepository(BooksCatalogDbContext _context) : IBooksRepository
    {

        public async Task<int> GetBooksTotalAsync(GetBooksQuery query, CancellationToken cancellationToken)
        {
            var books = _context.Books.AsQueryable();
            books = AddFiltering(query, books);
            return await books.CountAsync(cancellationToken);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(GetBooksQuery query, CancellationToken cancellationToken)
        {
            var books = _context.Books.AsQueryable();
            books = AddFiltering(query, books);
            var orderBy = query.OrderBy?.ToLower() ?? "title";

            books = AddOrdering(query, books, orderBy);

            return await books
              .AsNoTracking()
              .Skip(query.PageIndex * query.PageSize)
              .Take(query.PageSize)
              .ToListAsync(cancellationToken);
        }

        public async Task<Book> CreateBookAsync(Book book, CancellationToken cancellationToken)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync(cancellationToken);
            return book;
        }

        public async Task<List<Book>> CreateBooksAsync(List<Book> books, CancellationToken cancellationToken)
        {
            _context.Books.AddRange(books);
            await _context.SaveChangesAsync(cancellationToken);
            return books;
        }

        public async Task<Book?> GetBookByIdAsync(BookId bookId, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync([bookId], cancellationToken);
            return book;
        }

        public async Task<bool> UpdateBookAsync(Book book, CancellationToken cancellationToken)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        private static IQueryable<Book> AddOrdering(GetBooksQuery query, IQueryable<Book> books, string orderBy)
        {
            books = orderBy switch
            {
                "title" => query.IsAscending
                    ? books.OrderBy(b => b.Title)
                    : books.OrderByDescending(b => b.Title),
                "author" => query.IsAscending
                    ? books.OrderBy(b => b.Author)
                    : books.OrderByDescending(b => b.Author),
                "genre" => query.IsAscending
                    ? books.OrderBy(b => b.Genre)
                    : books.OrderByDescending(b => b.Genre),
                _ => books.OrderBy(b => b.Title)
            };
            return books;
        }

        private static IQueryable<Book> AddFiltering(GetBooksQuery query, IQueryable<Book> books)
        {
            if (!string.IsNullOrWhiteSpace(query.TitleSearch))
            {
                books = books.Where(b => EF.Functions.Like(b.Title, $"{query.TitleSearch}%"));
            }
            if (!string.IsNullOrWhiteSpace(query.AuthorSearch))
            {
                books = books.Where(b => EF.Functions.Like(b.Author, $"{query.AuthorSearch}%"));
            }
            if (!string.IsNullOrWhiteSpace(query.GenreSearch))
            {
                books = books.Where(b => EF.Functions.Like(b.Genre, $"{query.GenreSearch}%"));
            }

            return books;
        }

    }
}
