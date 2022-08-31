using FluentAssertions;
using TestSetup;
using WebAPI.Application.BookOperations.Commands.DeleteBook;

using Xunit;

namespace Application.BookOperations.Commands.DeleteCommand
{
  public class DeleteBookCommandValidatorTests : IClassFixture<CommonTestFixture>
  {
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void WhenInvalidBookIdIsGiven_Validator_ShouldBeReturnErrors(int bookId)
    {
      DeleteBookQuery command = new DeleteBookQuery(null);
      command.BookId = bookId;
      DeleteBookQueryValidator validator = new DeleteBookQueryValidator();
      var result = validator.Validate(command);
      result.Errors.Count.Should().BeGreaterThan(0);

    }
    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void WhenInvalidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int bookId)
    {
      //Arrange
      DeleteBookQuery command = new DeleteBookQuery(null);
      command.BookId = bookId;

      //Act && Assert
      DeleteBookQueryValidator validator = new DeleteBookQueryValidator();
      var result = validator.Validate(command);
      result.Errors.Count.Should().Be(0);
    }
  }
  
}