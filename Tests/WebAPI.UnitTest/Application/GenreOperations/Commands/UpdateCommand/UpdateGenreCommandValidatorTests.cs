using FluentAssertions;
using TestSetup;
using WebAPI.Application.GenreOperations.Commands.UpdateGenre;
using Xunit;

namespace Application.GenreOperations.Commands.UpdateCommand
{
  public class UpdateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
  {
    [Theory]
    [InlineData(0,"abc")]
    [InlineData(1,"ab")]
    [InlineData(1,"")]
    [InlineData(1," ")]
    public void WhenInvalidGenreIdIsGiven_Update_ShouldBeReturn(int genreId,string name)
    {
      UpdateGenreQuery command = new UpdateGenreQuery(null);
      command.Model = new UpdateGenreModel(){
        Name = name
      };
      command.GenreId = genreId;
      UpdateGenreQueryValidator validator = new UpdateGenreQueryValidator();
      var result = validator.Validate(command);

      result.Errors.Count.Should().BeGreaterThan(0);
    }
    [Theory]
    [InlineData(1,"abc")]
    public void WhenInvalidGenreIdIsGiven_Update_ShouldNotBeReturn(int genreId,string name)
    {
      UpdateGenreQuery command = new UpdateGenreQuery(null);
      command.Model = new UpdateGenreModel(){
        Name = name
      };
      command.GenreId = genreId;
      UpdateGenreQueryValidator validator = new UpdateGenreQueryValidator();
      var result = validator.Validate(command);

      result.Errors.Count.Should().Be(0);
    }
  }
}