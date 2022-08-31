using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebAPI.Application.BookOperations.Commands.GetById;
using WebAPI.DbOperations;
using Xunit;

namespace Application.BookOperations.Queries
{
  public class GetBookDetailQueryTests : IClassFixture<CommonTestFixture>
  {
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public GetBookDetailQueryTests(CommonTestFixture test)
    {
      _context = test.Context;
      _mapper = test.Mapper;
    }
    [Fact]
    public void WhenBookIdIsGivenWrong_InvalidOperationException_ShoulBeReturn()
    {
      GetBookByIdQuery query = new GetBookByIdQuery(_context,_mapper);
      query.BookId = 0;
      FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Bulunamadı");
    }
    [Fact]
    public void WhenBookIdIsGivenTrue_InvalidOperationException_ShouldBeReturn()
    {
      //Arrange
      GetBookByIdQuery query = new GetBookByIdQuery(_context,_mapper);
      query.BookId = 1;
      
      //Act
      FluentActions.Invoking(() => query.Handle()).Invoke();

      //Assert
      var book = _context.Books.SingleOrDefault(b => b.Id == query.BookId);
      book.Should().NotBeNull();
    }
  }
}