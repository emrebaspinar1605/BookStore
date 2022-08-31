using System;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace TestSetup
{
  public static class Authors
  {
    public static void AddAuthors(this BookStoreDbContext context)
    {
      context.Authors.AddRange(
        new Author{Name = "Arthur Conan",SurName ="Doyle",BirthDate = new DateTime(1859,05,22),BookId = 1},

        new Author{Name = "Halide Edib",SurName = "Adıvar",BirthDate = new DateTime(1884,06,11),BookId = 2},
        
        new Author{Name = "Cengiz",SurName = "Aytmatov",BirthDate = new DateTime(1928,12,12),BookId = 3}
        );
        context.SaveChanges();
    }
  }

}