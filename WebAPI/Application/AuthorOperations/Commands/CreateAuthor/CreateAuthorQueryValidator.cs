using System;
using FluentValidation;

namespace WebAPI.Application.AuthorOperations.Commands.CreateAuthor
{
  public class CreateAuthorQueryValidator : AbstractValidator<CreateAuthorQuery>
  {
    public CreateAuthorQueryValidator()
    {
      RuleFor(x => x.Model.BirthDate).LessThan(DateTime.Now);
      RuleFor(x => x.Model.Name).NotEmpty()
      .NotNull().MinimumLength(2);
      RuleFor(x => x.Model.SurName).NotEmpty().NotNull().MinimumLength(2);
      RuleFor(x => x.Model.BookId).NotEmpty().NotNull().GreaterThan(0);
    }
  }
}