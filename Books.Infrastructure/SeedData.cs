using Books.Domain.Models;

namespace Books.Infrastructure
{
    internal class SeedData
    {
        public static IEnumerable<Book> Books =>
           new List<Book>
           {
                Book.Create("A Hero of Our Time", "Lermontov, Mikhail", "Literary Fiction"),
                Book.Create("Aelita", "Tolstoy, Alexey", "Science Fiction"),
                Book.Create("The Novice", "Lermontov, Mikhail", "Thriller"),
                Book.Create("Anna Karenina", "Tolstoy, Leo", "Classic Romance"),
                Book.Create("Solaris", "Lem, Stanislav", "Science Fiction"),
                Book.Create("The Master and Margarita", "Bulgakov, Mikhail", "Classic Romance"),
                Book.Create("Doctor Zhivago", "Pasternak, Boris", "Classic Romance"),
                Book.Create("Dog's Heart", "Bulgakov, Mikhail", "Science Fiction"),
                Book.Create("From Russia with Love (James Bond)", "Fleming, Ian", "Thriller"),
                Book.Create("War and Peace", "Tolstoy, Leo", "Classic Romance")
           };
    }
}
