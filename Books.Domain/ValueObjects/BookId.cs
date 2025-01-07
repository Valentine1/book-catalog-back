namespace Books.Domain.ValueObjects
{
    public record BookId
    {
        public int Value { get; }
        private BookId(int value) => Value = value;
        public static BookId Of(int value)
        {
            return new BookId(value);
        }
    }
}
