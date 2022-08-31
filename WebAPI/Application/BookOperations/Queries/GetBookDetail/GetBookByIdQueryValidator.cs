using FluentValidation;
using WebAPI.Application.BookOperations.Commands.GetById;

namespace WebAPI.Application.BookOperations.Queries.GetById
{
  public class GetBookByIdQueryValidator :AbstractValidator<GetBookByIdQuery>
  {
    public GetBookByIdQueryValidator()
    {
      RuleFor(c=> c.BookId).NotEmpty().GreaterThan(0);
    }
  }
}