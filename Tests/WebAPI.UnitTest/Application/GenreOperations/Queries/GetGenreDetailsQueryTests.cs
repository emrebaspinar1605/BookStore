using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebAPI.Application.GenreOperations.Queries.GetGenreDetail;
using WebAPI.DbOperations;
using Xunit;

namespace Application.GenreOperations.Queries
{
  public class GetGenreDetailsQueryTests : IClassFixture<CommonTestFixture>
  {
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public GetGenreDetailsQueryTests(CommonTestFixture test)
    {
      _context = test.Context;
      _mapper = test.Mapper;
    }
    [Fact]
    public void  WhenGenreIdIsGivenWrong_InvalidOperationException_ShouldBeReturn()
    {
      GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
      query.GenreId = 0;

       FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Türü Bulunamadı");
    }
    [Fact]
    public void  WhenGenreIdIsGiven_InvalidOperationException_ShouldBeReturn()
    {
      GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
      query.GenreId = 1;

      FluentActions.Invoking(() => query.Handle()).Invoke();

      var genre = _context.Genres.SingleOrDefault(g => g.Id == query.GenreId);
      genre.Should().NotBeNull();

    }
  }
}