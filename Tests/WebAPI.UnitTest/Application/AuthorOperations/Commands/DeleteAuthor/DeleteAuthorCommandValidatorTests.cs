using FluentAssertions;
using TestSetup;
using WebAPI.Application.AuthorOperations.Commands.DeleteAuthor;
using Xunit;

namespace Application.AuthorOperations.Commands.DeleteCommand
{
  public class DeleteAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
  {
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void WhenInvalidAuthorIdIsGiven_Validator_ShouldBeReturn(int authorId)
    {
      DeleteAuthorQuery command = new DeleteAuthorQuery(null);
      command.AuthorId = authorId;
      DeleteAuthorQueryValidator validator = new DeleteAuthorQueryValidator();

      var result = validator.Validate(command);
      result.Errors.Count.Should().BeGreaterThan(0);
    }
     [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    public void WhenValidAuthorIdIsGiven_Validator_ShouldNotBeReturn(int authorId)
    {
      DeleteAuthorQuery command = new DeleteAuthorQuery(null);
      command.AuthorId = authorId;
      DeleteAuthorQueryValidator validator = new DeleteAuthorQueryValidator();

      var result = validator.Validate(command);
      result.Errors.Count.Should().Be(0);
    }
  }
}