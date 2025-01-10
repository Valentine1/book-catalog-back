using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Application.CQRS;
using Books.Application.Dtos;
using FluentValidation;

namespace Books.Application.Books.Commands.CreateBooks
{
    public record CreateBooksCommand(List<BookDto> Books) : ICommand<CreateBooksResult>;


    public record CreateBooksResult(List<int> Ids);

    public class CreateBooksCommandValidator : AbstractValidator<CreateBooksCommand>
    {
        public CreateBooksCommandValidator()
        {
            RuleFor(x => x.Books)
                .NotEmpty().WithMessage("At least one book is required");

            RuleForEach(x => x.Books)
                .ChildRules(book =>
                {
                    book.RuleFor(x => x.Title)
                        .NotEmpty().WithMessage("Title is required")
                        .MaximumLength(200).WithMessage("Max Title length exceeded");

                    book.RuleFor(x => x.Author)
                        .NotEmpty().WithMessage("Author is required")
                        .MaximumLength(150).WithMessage("Max Author length exceeded");

                    book.RuleFor(x => x.Title)
                        .NotEmpty().WithMessage("Genre is required")
                        .MaximumLength(50).WithMessage("Max Genre length exceeded");
                });
        }
    }
}
