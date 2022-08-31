using FluentAssertions;
using TestSetup;
using WebAPI.Application.GenreOperations.Queries.GetGenreDetail;
using Xunit;

namespace Application.GenreOperations.Queries
{
  public class GetGenreDetailsQueryValidatorTests : IClassFixture<CommonTestFixture>
  {
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void WhenInvalidGenreIdIsGiven_Validator_ShouldBeReturnError(int genreId)
    {
      GetGenreDetailQuery query = new GetGenreDetailQuery(null,null);
      query.GenreId = genreId;

      GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
      var result = validator.Validate(query);
      
      result.Errors.Count.Should().BeGreaterThan(0);

    } 
    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    public void WhenInvalidGenreIdIsGiven_Validator_ShouldNotBeReturnError(int genreId)
    {
      GetGenreDetailQuery query = new GetGenreDetailQuery(null,null);
      query.GenreId = genreId;

      GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
      var result = validator.Validate(query);
      
      result.Errors.Count.Should().Be(0);

    } 
  }
}