using System;
using FluentAssertions;
using TestSetup;
using WebAPI.Application.BookOperations.Commands.CreateBook;
using WebAPI.Application.BookOperations.Queries.CreateBook;
using Xunit;

namespace Application.BookOperations.Commands.CreateBook
{
  public class CreateBookCommandValidatorTests: IClassFixture<CommonTestFixture>
  {  
    [Theory]
    [InlineData("Sherlock Holmes",0,0)]
    [InlineData("Sherlock Holmes",0,1)]
    [InlineData("Sherlock Holmes",1,0)]
    [InlineData("",0,0)]
    [InlineData("",0,1)]
    [InlineData("",1,0)]
    [InlineData("Sh",100,1)]
    [InlineData("Sh",0,1)]
    [InlineData("Sh",100,0)]
    [InlineData("Sh",0,0)]
    [InlineData(" ",100,1)]
    public void  WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name , int pageCount,int genreId)
    {
      //arrange
      CreateBookQuery command = new CreateBookQuery(null,null);
      command.Model = new CreateBookModel(){
        GenreID = genreId,
        Name = name,
        PageCount = pageCount,
        PublishDate = DateTime.Now.Date.AddYears(-1)
      };
      //act
      CreateBookQueryValidator validator = new CreateBookQueryValidator();
      var result = validator.Validate(command);
      //assert
      result.Errors.Count.Should().BeGreaterThan(0);
    }
    [Fact]
    public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
    {
      CreateBookQuery command = new CreateBookQuery(null,null);
      command.Model = new CreateBookModel(){
        GenreID = 2,
        Name = "Araba Sevgisi",
        PageCount = 240,
        PublishDate = DateTime.Now.Date.AddYears(+1)
      };

      CreateBookQueryValidator validator = new CreateBookQueryValidator();
      var result = validator.Validate(command);

      result.Errors.Count.Should().BeGreaterThan(0); 
    }

    [Fact]
    public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
    {
      CreateBookQuery command = new CreateBookQuery(null,null);
      command.Model = new CreateBookModel(){
        GenreID = 2,
        Name = "Araba Sevgileri",
        PageCount = 240,
        PublishDate = DateTime.Now.Date.AddYears(-10)
      };

      CreateBookQueryValidator validator = new CreateBookQueryValidator();
      var result = validator.Validate(command);
 
      result.Errors.Count.Should().Be(0); 
    }
  }
}