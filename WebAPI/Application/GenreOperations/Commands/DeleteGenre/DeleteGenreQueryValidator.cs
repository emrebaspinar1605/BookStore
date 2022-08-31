using FluentValidation;

namespace WebAPI.Application.GenreOperations.Commands.DeleteGenre
{
  public class DeleteGenreQueryValidator : AbstractValidator<DeleteGenreQuery>
  {
    public DeleteGenreQueryValidator()
    {
      RuleFor(g => g.GenreId).GreaterThan(0).NotEmpty();
    }
  }
}