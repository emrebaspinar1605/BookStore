using System;
using System.Linq;
using FluentValidation;
using WebAPI.DbOperations;

namespace WebAPI.Application.AuthorOperations.Commands.DeleteAuthor
{
  public class DeleteAuthorQueryValidator : AbstractValidator<DeleteAuthorQuery>
  {
    public DeleteAuthorQueryValidator()
    {
      RuleFor(x => x.AuthorId).NotEmpty().GreaterThan(0);
    }
  }
}