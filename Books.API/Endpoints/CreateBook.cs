using Books.Application.Books.Commands.CreateBook;
using Books.Application.Dtos;
using Carter;
using Mapster;
using MediatR;

namespace Books.API.Endpoints
{
    public record CreateBookRequest(BookDto Book);
    public record CreateBookResponse(int Id);

    public class CreateBook : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("books", async (CreateBookRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateBookCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateBookResponse>();

                return Results.Created($"/books/{response.Id}", response);
            })
            .WithName("CreateBook")
            .Produces<CreateBookResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Book")
            .WithDescription("Create Book");
        }
    }
}
