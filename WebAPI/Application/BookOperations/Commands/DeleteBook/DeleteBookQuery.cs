using System;
using System.Linq;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.BookOperations.Commands.DeleteBook
{
  public class DeleteBookQuery
  {
    public int BookId { get; set;}
    private readonly IBookStoreDbContext _context;

    public DeleteBookQuery(IBookStoreDbContext context)
    {
      _context = context;
    }
    public void Handle()
    {
      var book = _context.Books.SingleOrDefault(x=> x.Id == BookId);
      if (book is null)
        throw new InvalidOperationException("Böyle bir kitap bulunmamaktadır.");
      _context.Books.Remove(book);
      _context.SaveChanges();
    }
  }
}