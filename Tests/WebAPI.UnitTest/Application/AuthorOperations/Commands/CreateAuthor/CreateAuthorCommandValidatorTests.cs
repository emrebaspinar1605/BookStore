using System;
using FluentAssertions;
using TestSetup;
using WebAPI.Application.AuthorOperations.Commands.CreateAuthor;
using Xunit;

namespace Application.AuthorOperations.Commands.CreateAuthor
{
  public class CreateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
  {
    [Theory]
    [InlineData("as","ba",0)]
    [InlineData("as","b",0)]
    [InlineData("as","b",1)]
    [InlineData("a","ba",0)]
    [InlineData("a","ba",1)]
    [InlineData("as","ba",0)]
    [InlineData("a","b",1)]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name,string surName ,int bookId)
    {
      CreateAuthorQuery command = new CreateAuthorQuery(null,null);
      command.Model = new CreateAuthorModel()
      {
        BookId = bookId,
        BirthDate = DateTime.Now.Date.AddYears(-1),
        Name = name,
        SurName = surName
      };

      CreateAuthorQueryValidator validator = new CreateAuthorQueryValidator();
      var result = validator.Validate(command);

      result.Errors.Count.Should().BeGreaterThan(0);
    }
    [Fact]
    public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnErrors()
    {
      CreateAuthorQuery command = new CreateAuthorQuery(null,null);
      command.Model = new CreateAuthorModel()
      {
        BookId = 2,
        Name = "ali",
        SurName = "Rıza",
        BirthDate = DateTime.Now.Date.AddYears(+1)
      };

      CreateAuthorQueryValidator validator = new CreateAuthorQueryValidator();
      var result = validator.Validate(command);

      result.Errors.Count.Should().BeGreaterThan(0);
    }
    [Fact]
    public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnErrors()
    {
      CreateAuthorQuery command = new CreateAuthorQuery(null,null);
      command.Model = new CreateAuthorModel()
      {
        BookId = 1,
        BirthDate = DateTime.Now.Date.AddYears(-1),
        Name = "Ahbab",
        SurName = "Kesen"
      };

      CreateAuthorQueryValidator validator = new CreateAuthorQueryValidator();
      var result = validator.Validate(command);

      result.Errors.Count.Should().Be(0);
    }
  }
}