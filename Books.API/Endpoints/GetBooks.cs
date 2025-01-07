using Books.Application.Books.Queries.GetBooks;
using Books.Application.Dtos;
using Carter;
using MediatR;
using Mapster;

namespace Books.API.Endpoints
{
    public record GetBooksResponse(IEnumerable<BookDto> Books);

    public class GetBooks : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/books", async (ISender sender) =>
            {
                var result = await sender.Send(new GetBooksQuery());

                var response = result.Adapt<GetBooksResponse>();

                return Results.Ok(response);
            })
            .WithName("GetBooks")
            .Produces<GetBooksResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Books")
            .WithDescription("Get Books");
        }
    }
}
