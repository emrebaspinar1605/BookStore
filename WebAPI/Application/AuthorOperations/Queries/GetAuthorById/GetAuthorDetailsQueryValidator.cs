using FluentValidation;
using WebAPI.Application.BookOperations.Commands.GetById;

namespace WebAPI.Application.AuthorOperations.Queries.GetAuthorById
{
  public class GetAuthorDetailsQueryValidator : AbstractValidator<GetAuthorDetailsQuery>
  {
    public GetAuthorDetailsQueryValidator()
    {
      RuleFor(a => a.AuthorId).NotEmpty().GreaterThan(0);
    }
  }
}