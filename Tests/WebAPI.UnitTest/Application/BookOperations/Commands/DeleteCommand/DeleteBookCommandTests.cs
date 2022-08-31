using System;
using System.Linq;
using FluentAssertions;
using TestSetup;
using WebAPI.Application.BookOperations.Commands.DeleteBook;
using WebAPI.DbOperations;
using Xunit;

namespace Application.BookOperations.Commands.DeleteCommand
{
  public class DeleteBookCommandTests : IClassFixture<CommonTestFixture>
  {
    private readonly BookStoreDbContext _context;
    public DeleteBookCommandTests(CommonTestFixture test)
    {
      _context = test.Context;
    }
    [Fact]
    public void WhenBookIdIsGivenWrong_Delete_ShouldBeReturn()
    {
      //Arrange
      DeleteBookQuery command = new DeleteBookQuery(_context);
      command.BookId = 0;

      //Act && Assert
      FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir kitap bulunmamaktadır.");
    }
    [Fact]
    public void WhenBookIdIsGiven_Delete_ShouldBeDeleted()
    {
      //Arrange
      DeleteBookQuery command = new DeleteBookQuery(_context);
      command.BookId = 1;
      
      //Act
      FluentActions.Invoking(() => command.Handle()).Invoke();

      //Assert
      var book = _context.Books.SingleOrDefault(b => b.Id == command.BookId);
      book.Should().BeNull();

    }
  }
}