using FluentValidation;

namespace WebAPI.Application.AuthorOperations.Commands.UpdateAuthor
{
  public class UpdateAuthorQueryValidator : AbstractValidator<UpdateAuthorQuery>
  {
    public UpdateAuthorQueryValidator()
    {
      RuleFor(x => x.AuthorId).NotNull().NotEmpty().GreaterThan(0);
      RuleFor(x => x.Model.Name ).MinimumLength(3).NotNull();
      RuleFor(x => x.Model.SurName).MinimumLength(2).NotNull();
    }
  }
}