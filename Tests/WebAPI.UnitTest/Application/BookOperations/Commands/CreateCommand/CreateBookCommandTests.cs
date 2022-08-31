using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebAPI.Application.BookOperations.Commands.CreateBook;
using WebAPI.DbOperations;
using WebAPI.Entities;
using Xunit;

namespace Application.BookOperations.Commands.CreateBook
{
  public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
  {
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateBookCommandTests(CommonTestFixture testFix)
    {
      _context = testFix.Context;
      _mapper = testFix.Mapper;
    }
    [Fact]
    public void  WhenAlreadyExistBookNameIsGiven_InvalidOperationException_ShouldBeReturn()
    {
      //arrange (Hazırlık)
      var book = new Book(){Name ="WhenAlreadyExistBookNameIsGiven_InvalidOperationException_ShouldBeReturn", GenreId = 2 ,PageCount = 350,PublishDate = new DateTime(1958,05,12),IsActive = true};
      _context.Books.Add(book);
      _context.SaveChanges();

      CreateBookQuery command = new CreateBookQuery(_context,_mapper);
      command.Model = new CreateBookModel(){Name = book.Name};
      
      //act & assert  (Çalıştırma ve Doğrulama)
      FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Zaten Mevcut");
    }
    [Fact] 
    public void WhenInvalidInputsAreGiven_Book_ShouldBeCreated()
    {
      //arrange
        CreateBookQuery command = new CreateBookQuery(_context,_mapper);
        CreateBookModel model = new CreateBookModel(){
          Name = "Back To The Future",
          GenreID = 3,
          PageCount = 216,
          PublishDate = new DateTime(1985,05,30)
        };
        command.Model = model;
      
      //act
      FluentActions.Invoking(() => command.Handle()).Invoke();

      //assert
      var book = _context.Books.SingleOrDefault(book => book.Name == model.Name);
      book.Should().NotBeNull();
      book.PageCount.Should().Be(model.PageCount);
      book.PublishDate.Should().Be(model.PublishDate);
      book.GenreId.Should().Be(model.GenreID);

    }
  }
}