using FluentAssertions;
using TestSetup;
using WebAPI.Application.AuthorOperations.Queries.GetAuthorById;
using Xunit;

namespace Application.AuthorOperations.Queries
{
  public class GetDetailAuthorQueryValidatorTests : IClassFixture<CommonTestFixture>
  {
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void WhenInvalidAuthorIdIsGiven_Validator_ShouldBeReturnError(int authorId)
    {
      GetAuthorDetailsQuery query = new GetAuthorDetailsQuery(null,null);
      query.AuthorId = authorId;

      GetAuthorDetailsQueryValidator validator = new GetAuthorDetailsQueryValidator();
      var result = validator.Validate(query);

      result.Errors.Count.Should().BeGreaterThan(0);
    }
    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    public void WhenValidAuthorIdIsGiven_Validator_ShouldBeReturnError(int authorId)
    {
      GetAuthorDetailsQuery query = new GetAuthorDetailsQuery(null,null);
      query.AuthorId = authorId;

      GetAuthorDetailsQueryValidator validator = new GetAuthorDetailsQueryValidator();
      var result = validator.Validate(query);

      result.Errors.Count.Should().Be(0);
    }
  }
}