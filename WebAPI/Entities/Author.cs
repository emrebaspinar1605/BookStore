using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
  public class Author
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public DateTime BirthDate { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
  }
}