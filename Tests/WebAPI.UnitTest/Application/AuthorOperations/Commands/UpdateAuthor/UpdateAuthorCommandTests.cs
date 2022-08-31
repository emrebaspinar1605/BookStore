using System;
using System.Linq;
using FluentAssertions;
using TestSetup;
using WebAPI.Application.AuthorOperations.Commands.UpdateAuthor;
using WebAPI.DbOperations;
using Xunit;

namespace Application.AuthorOperations.Commands.UpdateAuthor
{
  public class UpdateAuthorCommandTests : IClassFixture<CommonTestFixture>
  {
    private readonly BookStoreDbContext _context;
    public UpdateAuthorCommandTests(CommonTestFixture test)
    {
      _context = test.Context;
    }
    [Fact]
    public void WhenGivenAuthorIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
    {
      UpdateAuthorQuery command = new UpdateAuthorQuery(_context);
      command.AuthorId=0;
      FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar Bulunamadı.");
    }
    [Fact]
    public void WhenGivenAuthorIdIsinDB_InvalidOperationException_ShouldBeReturn()
    {
      UpdateAuthorQuery command = new UpdateAuthorQuery(_context);
      command.Model = new UpdateAuthorModel(){Name = "Sigmund", SurName="Freud"};
      command.AuthorId=1;    
      FluentActions.Invoking(() => command.Handle()).Invoke();
        
      var author=_context.Authors.SingleOrDefault(author=>author.Id == command.AuthorId);
      author.Should().NotBeNull(null);
    }
  }
}