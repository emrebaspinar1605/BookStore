using System;
using System.Linq;
using FluentAssertions;
using TestSetup;
using WebAPI.Application.AuthorOperations.Commands.DeleteAuthor;
using WebAPI.DbOperations;
using Xunit;

namespace Application.AuthorOperations.Commands.DeleteCommand
{
  public class DeleteAuthorCommandTests : IClassFixture<CommonTestFixture>
  {
    private readonly BookStoreDbContext _context ;
    public DeleteAuthorCommandTests(CommonTestFixture test)
    {
      _context = test.Context;
    }
    [Fact]
    public void WhenAuthorIdIsGivenWrong_Delete_ShouldBeReturn()
    {
      DeleteAuthorQuery command = new DeleteAuthorQuery(_context);
      command.AuthorId = 0;

      FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek Yazar Bulunamadı");
    }
    [Fact]
    public void WhenAuthorIdIsGiven_Delete_ShouldBeReturn()
    {
      DeleteAuthorQuery command = new DeleteAuthorQuery(_context);
      command.AuthorId = 1;

      FluentActions.Invoking(() => command.Handle()).Invoke();

      var author = _context.Authors.SingleOrDefault(a => a.Id == command.AuthorId);
      author.Should().BeNull();
    }
  }
}