using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebAPI.Application.BookOperations.Commands.UpdateBook;
using WebAPI.DbOperations;
using Xunit;

namespace Application.BookOperations.Commands.UpdateCommand
{
  public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
  {
    private readonly BookStoreDbContext _context;

    public UpdateBookCommandTests(CommonTestFixture testFixture)
    {
      _context = testFixture.Context;
    }
    [Fact]
    public void WhenBookIdIsGivenWrong_Update_ShouldBeReturn()
    {
      //Arrange
      UpdateBookQuery command = new UpdateBookQuery(_context);
      command.BookId = 999;
      
      //Act && Assert (Çalıştır Ve Doğrula)
      FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir kitap bulunamadı");
    }
    [Fact]
    public void WhenUpdateModelIsTrue_Book_ShouldNotBeReturn()
    {
      //Arrange
      UpdateBookQuery command = new UpdateBookQuery(_context);
      
      UpdateBookModels model = new UpdateBookModels()
      {
        
        Name = "WhenUpdateModelIsTrue_Book_ShouldBeUpdated",
        GenreId = 1,

      };
      command.Model = model;
      command.BookId = 1;
      
      //Arc
      FluentActions.Invoking(() => command.Handle()).Invoke();

      //Assert
      var book = _context.Books.SingleOrDefault(b => b.Id == command.BookId);
      book.Should().NotBeNull();
      book.Should().Be(command.Model.GenreId);
    }
  }
}