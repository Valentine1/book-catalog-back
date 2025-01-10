using System.Net.Http;
using Books.Application.Books.Commands.CreateBooks;
using Books.Application.Dtos;
using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Endpoints
{
    public record CreateBooksRequest(List<BookDto> Books);
    public record CreateBooksResponse(List<int> Ids);

    public class CreateBooks : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("books/upload", async (
                CreateBooksRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateBooksCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateBooksResponse>();

                var locationUrls = string.Join(",", response.Ids.Select(id => $"/books/{id}"));
                return Results.Created(locationUrls, response);

            })
            .WithName("CreateBooksBulk")
            .Produces<CreateBooksResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Book")
            .WithDescription("Create Book");
        }
    }
}

