using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebAPI.Application.AuthorOperations.Commands.CreateAuthor;
using WebAPI.DbOperations;
using WebAPI.Entities;
using Xunit;

namespace Application.AuthorOperations.Commands.CreateAuthor
{
  public class CreateAuthorCommandTests : IClassFixture<CommonTestFixture>
  {
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public  CreateAuthorCommandTests(CommonTestFixture test)
    {
      _context = test.Context;
      _mapper = test.Mapper;
    }
    [Fact]
    public void WhenAlreadyExistAuthorNameIsGiven_InvalidOperationException_ShouldBeReturn()
    {
      var author = new Author()
      {
        Name = "WhenAlreadyExistAuthorNameIsGiven",
        BookId = 1,
        BirthDate = new DateTime(1985,01,01),
        SurName = "InvalidOperationException"
      };
      _context.Authors.Add(author);
      _context.SaveChanges();

      CreateAuthorQuery command = new CreateAuthorQuery(_context,_mapper);
      command.Model = new CreateAuthorModel()
      {
        Name = author.Name,
        SurName = author.SurName
      };

      FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar Zaten Mevcut");
    }
    [Fact]
    public void WhenInvalidInputsAreGiven_Author_ShouldBeCreated()
    {
      CreateAuthorQuery command = new CreateAuthorQuery(_context,_mapper);

      CreateAuthorModel model= new CreateAuthorModel()
      {
        Name = "Sunay",
        SurName = "Akın",
        BirthDate = new DateTime(1975,05,30),
        BookId = 1
      };
      command.Model = model;

      FluentActions.Invoking(() => command.Handle()).Invoke();

      var author = _context.Authors.SingleOrDefault(author => author.Name == model.Name && author.SurName == model.SurName);
      author.Should().NotBeNull();
      author.BirthDate.Should().Be(model.BirthDate);
      author.BookId.Should().Be(model.BookId);
    }
  }
}