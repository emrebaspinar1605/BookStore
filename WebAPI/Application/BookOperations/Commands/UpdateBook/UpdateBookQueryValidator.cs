using FluentValidation;
using WebAPI.Application.BookOperations.Commands.UpdateBook;

namespace WebAPI.Application.BookOperations.Queries.UpdateBook
{
  public class UpdateBookQueryValidator :AbstractValidator<UpdateBookQuery>
  {
    public UpdateBookQueryValidator()
    {
      RuleFor(c=> c.BookId).NotEmpty().GreaterThan(0);
      RuleFor(c=> c.Model.GenreId).GreaterThan(0).LessThan(5);
      RuleFor(c=> c.Model.Name).MinimumLength(3).NotEmpty();
    }
  }
}