using System;
using System.Linq;
using FluentAssertions;
using TestSetup;
using WebAPI.Application.GenreOperations.Commands.DeleteGenre;
using WebAPI.DbOperations;
using Xunit;

namespace Application.GenreOperations.Commands.DeleteCommand
{
  public class DeleteGenreCommandTests :IClassFixture<CommonTestFixture>
  {
    private readonly BookStoreDbContext _context;
    public DeleteGenreCommandTests(CommonTestFixture test)
    {
      _context = test.Context;
    }
    [Fact]
    public void WhenGenreIdIsGivenWrong_Delete_ShouldBeReturn()
    {
      //Arrange
      DeleteGenreQuery query = new DeleteGenreQuery(_context);
      query.GenreId = 0;

      //Act && Assert
      FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü Bulunamadı.");
    }
    [Fact]
    public void WhenGenreIdIsGiven_Delete_ShouldBeRetun()
    {
      //Arrange
      DeleteGenreQuery query = new DeleteGenreQuery(_context);
      query.GenreId = 1;

      //Act 
      FluentActions.Invoking(() => query.Handle()).Invoke();

      //Assert
      var genre = _context.Genres.SingleOrDefault(g => g.Id == query.GenreId);
      genre.Should().BeNull();
    }
  }
}