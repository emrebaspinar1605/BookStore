using FluentAssertions;
using TestSetup;
using WebAPI.Application.GenreOperations.Commands.CreateGenre;
using Xunit;

namespace Application.GenreOperations.Commands.CreateCommand
{
  public class CreateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
  {
    [Theory]
    [InlineData("a")]
    [InlineData("ab")]
    [InlineData("")]
    [InlineData(" ")]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
    {
      CreateGenreQuery command = new CreateGenreQuery(null);
      command.Model = new CreateGenreModel()
      {
        Name = name
      };
      //Act
      CreateGenreQueryValidator validator = new CreateGenreQueryValidator();
      var result = validator.Validate(command);

      //Assert
      result.Errors.Count.Should().BeGreaterThan(0);
    }
    [Theory]
    [InlineData("abc")]
    [InlineData("abcd")]
    [InlineData("abcde")]
    public void WhenInvalidInputsAreGiven_Validator_ShouldNotBeReturnErrors(string name)
    {
      CreateGenreQuery command = new CreateGenreQuery(null);
      command.Model = new CreateGenreModel()
      {
        Name = name
      };
      //Act
      CreateGenreQueryValidator validator = new CreateGenreQueryValidator();
      var result = validator.Validate(command);

      //Assert
      result.Errors.Count.Should().Be(0);
    }
  }
}