using System;
using System.Linq;
using FluentAssertions;
using TestSetup;
using WebAPI.Application.GenreOperations.Commands.DeleteGenre;
using WebAPI.Application.GenreOperations.Commands.UpdateGenre;
using WebAPI.DbOperations;
using Xunit;

namespace Application.GenreOperations.Commands.UpdateCommand
{
  public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture>
  {
    private readonly BookStoreDbContext _context;
    public UpdateGenreCommandTests(CommonTestFixture test)
    {
      _context = test.Context;
    }
    [Fact]
    public void WhenInvalidGenreIdIsGiven_Update_ShouldBeReturn()
    {
      UpdateGenreQuery command = new UpdateGenreQuery(_context);
      command.GenreId = 0;
      UpdateGenreModel model = new UpdateGenreModel()
      {
        Name = "WhenInvalidGenreIdIsGiven_Update_ShouldBeReturn"
      };

      //"Aynı İsimli Bir Kitap Türü Mevcuttur"
      FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle Bir Kitap Türü Yok");
    }
     [Fact]
    public void WhenValidGenreIdIsGiven_Update_ShouldBeReturn()
    {
      UpdateGenreQuery command = new UpdateGenreQuery(_context);
      command.GenreId = 1;
      UpdateGenreModel model = new UpdateGenreModel()
      {
        Name = "WhenInvalidGenreIdIsGiven_Update_ShouldBeReturn"
      };
      command.Model = model;
      //"Aynı İsimli Bir Kitap Türü Mevcuttur"
      FluentActions.Invoking(() => command.Handle()).Invoke();

      var genre = _context.Genres.SingleOrDefault(g => g.Id == command.GenreId);
      genre.Should().NotBeNull();
    }
  }
}