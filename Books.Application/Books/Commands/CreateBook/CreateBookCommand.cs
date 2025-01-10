using Books.Application.CQRS;
using Books.Application.Dtos;
using FluentValidation;

namespace Books.Application.Books.Commands.CreateBook
{
    public record CreateBookCommand(BookDto Book) : ICommand<CreateBookResult>;


    public record CreateBookResult(int Id);

    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Book.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(200).WithMessage("Max Title length exceeded");
            RuleFor(x => x.Book.Author)
                .NotEmpty().WithMessage("Author is required")
                .MaximumLength(150).WithMessage("Max Author length exceeded");
            RuleFor(x => x.Book.Genre)
                .NotEmpty().WithMessage("Genre is required")
                .MaximumLength(50).WithMessage("Max Genre length exceeded");
        }
    }
}
