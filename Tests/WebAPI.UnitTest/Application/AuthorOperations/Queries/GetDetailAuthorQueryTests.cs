using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebAPI.Application.AuthorOperations.Queries.GetAuthorById;
using WebAPI.DbOperations;
using Xunit;

namespace Application.AuthorOperations.Queries
{
  public class GetDetailAuthorQueryTests
  {
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public GetDetailAuthorQueryTests(CommonTestFixture test)
    {
      _context = test.Context;
      _mapper = test.Mapper;
    }
    [Fact]
    public void WhenAuthorIdIsGivenWrong_InvalidOperationException_ShouldBeReturn()
    {
      GetAuthorDetailsQuery query = new GetAuthorDetailsQuery(_context,_mapper);
      query.AuthorId = 0;

      FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı");
    }
    [Fact]
    public void WhenAuthorIdIsGiven_InvalidOperationException_ShouldBeReturn()
    {
      GetAuthorDetailsQuery query = new GetAuthorDetailsQuery(_context,_mapper);
      query.AuthorId = 1;

      FluentActions.Invoking(() => query.Handle()).Invoke();

      var author = _context.Authors.SingleOrDefault(a => a.Id == query.AuthorId);
      author.Should().NotBeNull();
    }
  }
}