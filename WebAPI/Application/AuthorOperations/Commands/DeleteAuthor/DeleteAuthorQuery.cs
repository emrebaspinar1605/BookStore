using System;
using System.Linq;
using WebAPI.DbOperations;

namespace WebAPI.Application.AuthorOperations.Commands.DeleteAuthor
{
  public class DeleteAuthorQuery
  {
    public int AuthorId { get; set; }
    private readonly IBookStoreDbContext _context;

    public DeleteAuthorQuery(IBookStoreDbContext context)
    {
      _context = context;
    }

    public void Handle()
    {
      var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
     
      if (author is null)
      {
        throw new InvalidOperationException("Silinecek Yazar Bulunamadı");
      }
     
      _context.Authors.Remove(author);
      _context.SaveChanges();
    }
  }
}