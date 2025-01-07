namespace Books.Application.Dtos
{
    public record BookDto(
        int Id,
        string Title,
        string Author,
        string Genre);
}