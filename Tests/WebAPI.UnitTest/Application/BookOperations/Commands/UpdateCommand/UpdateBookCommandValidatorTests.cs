using TestSetup;
using WebAPI.Application.BookOperations.Commands.UpdateBook;
using WebAPI.Application.BookOperations.Queries.UpdateBook;
using Xunit;
using FluentAssertions;

namespace Application.BookOperations.Commands.UpdateCommand
{
  public class UpdateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
  {
    [Theory]
    [InlineData(1,0,"ab")]
    [InlineData(1,0,"abc")]
    [InlineData(1,1,"ab")]
    [InlineData(0,1,"abc")]
    [InlineData(0,1,"ab")]
    [InlineData(0,0,"abc")]
    [InlineData(1,1," ")]
    [InlineData(1,1,"")]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int bookId, int genreId, string name )
    {
      UpdateBookQuery command = new UpdateBookQuery(null);
      command.Model = new UpdateBookModels()
      {
        Name = name,
        GenreId = genreId
      };
      command.BookId = bookId;
      UpdateBookQueryValidator validator =new UpdateBookQueryValidator();
      var result = validator.Validate(command);
      result.Errors.Count.Should().BeGreaterThan(0);
    }
  
    [Theory]
    [InlineData(1,1,"ABC")]
    public void WhenInvalidInputsAreGiven_Validator_ShouldNotBeReturnErrors(int bookId,int genreId,string name)
    {
      UpdateBookQuery command = new UpdateBookQuery(null);
      command.Model = new UpdateBookModels()
      {
        GenreId = genreId,
        Name = name
      };
      command.BookId = bookId;
      UpdateBookQueryValidator validator = new UpdateBookQueryValidator();
      var result = validator.Validate(command);
      result.Errors.Count.Should().Be(0);

    }
  }
}