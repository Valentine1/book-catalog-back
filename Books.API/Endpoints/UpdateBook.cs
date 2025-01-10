using Books.Application.Books.Commands.UpdateBook;
using Books.Application.Dtos;
using Carter;
using Mapster;
using MediatR;

namespace Books.API.Endpoints
{
    public record UpdateBookRequest(BookDto Book);
    public record UpdateBookResponse(bool isSuccess);

    public class UpdateBook: ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("books", async (UpdateBookRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateBookCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateBookResponse>();
                if (!response.isSuccess)
                {
                    return Results.NotFound($"Book with ID {command.Book.Id} was not found");
                }

                return Results.Ok(response);
            })
            .WithName("UpdateBook")
            .Produces<CreateBookResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Book")
            .WithDescription("Update Book");
        }
    }
}
