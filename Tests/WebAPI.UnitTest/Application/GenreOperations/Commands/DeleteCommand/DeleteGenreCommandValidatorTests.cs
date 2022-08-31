using FluentAssertions;
using TestSetup;
using WebAPI.Application.GenreOperations.Commands.DeleteGenre;
using Xunit;

namespace Application.GenreOperations.Commands.DeleteCommand
{
  public class DeleteGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
  {
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void WhenInvalidInputsAreGiven_Genre_ShouldBeReturn(int genreId)
    {
      //Arrange
      DeleteGenreQuery query = new DeleteGenreQuery(null);
      query.GenreId = genreId;

      //Act && Assert
      DeleteGenreQueryValidator validator = new DeleteGenreQueryValidator();
      var result = validator.Validate(query);

      result.Errors.Count.Should().BeGreaterThan(0);
    }
    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    public void WhenInvalidInputsAreGiven_Genre_ShouldNotBeReturn(int genreId)
    {
      //Arrange
      DeleteGenreQuery query = new DeleteGenreQuery(null);
      query.GenreId = genreId;

      //Act && Assert
      DeleteGenreQueryValidator validator = new DeleteGenreQueryValidator();
      var result = validator.Validate(query);

      result.Errors.Count.Should().Be(0);
    }
  }
}