using FluentValidation;

namespace WebAPI.Application.GenreOperations.Commands.UpdateGenre
{
  public class UpdateGenreQueryValidator : AbstractValidator<UpdateGenreQuery>
  {
    public UpdateGenreQueryValidator()
    {
      RuleFor(g => g.Model.Name).MinimumLength(3).NotEmpty().NotNull();
      RuleFor(g => g.GenreId).GreaterThan(0).NotEmpty().NotNull();
    }
  }
}