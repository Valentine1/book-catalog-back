using Books.Application.CQRS;
using Books.Application.Dtos;
using FluentValidation;

namespace Books.Application.Books.Commands.UpdateBook
{
    public record UpdateBookCommand(BookDto Book) : ICommand<UpdateBookResult>;

    public record UpdateBookResult(bool IsSuccess);

    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Book.Id)
                .NotNull().WithMessage("Id is required");
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
