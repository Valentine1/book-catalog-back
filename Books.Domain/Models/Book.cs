using Books.Domain.ValueObjects;

namespace Books.Domain.Models
{
    public class Book : Entity<BookId>
    {
        public string Title { get; private set; } = default!;
        public string Author { get; private set; } = default!;
        public string Genre { get; private set; } = default!;

        public static Book Create(string title, string author, string genre)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(title);
            ArgumentException.ThrowIfNullOrWhiteSpace(author);
            ArgumentException.ThrowIfNullOrWhiteSpace(genre);

            var book = new Book
            {
                Title = title,
                Author = author,
                Genre = genre
            };

            return book;
        }
    }
}
