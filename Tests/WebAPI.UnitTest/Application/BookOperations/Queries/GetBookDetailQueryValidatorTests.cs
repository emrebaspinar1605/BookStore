using FluentAssertions;
using TestSetup;
using WebAPI.Application.BookOperations.Commands.GetById;
using WebAPI.Application.BookOperations.Queries.GetById;
using Xunit;

namespace Application.BookOperations.Queries
{
  public class GetBookDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
  {
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(-100)]
    public void WhenInvalidBookIdIsGiven_Validator_ShouldBeReturnError(int bookId)
    {
      //Arrange
      GetBookByIdQuery query = new GetBookByIdQuery(null,null);
      query.BookId = bookId;

      //Act && Assert
      GetBookByIdQueryValidator validator = new GetBookByIdQueryValidator();
      var result = validator.Validate(query);
      
      result.Errors.Count.Should().BeGreaterThan(0);
    }
    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    public void WhenValidBookIdIsGiven_Validator_ShouldNotBeReturnError(int bookId)
    {
      //Arrange
      GetBookByIdQuery query = new GetBookByIdQuery(null,null);
      query.BookId = bookId;

      //Act && Assert
      GetBookByIdQueryValidator validator = new GetBookByIdQueryValidator();
      var result = validator.Validate(query);

      result.Errors.Count.Should().Be(0);
    }

  }
}