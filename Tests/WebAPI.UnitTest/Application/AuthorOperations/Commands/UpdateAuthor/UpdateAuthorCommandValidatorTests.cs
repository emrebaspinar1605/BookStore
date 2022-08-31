using FluentAssertions;
using TestSetup;
using WebAPI.Application.AuthorOperations.Commands.UpdateAuthor;
using Xunit;

namespace Application.AuthorOperations.Commands.UpdateAuthor
{
  public class UpdateAuthorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [InlineData("","")]
        [InlineData(" "," ")]
        [InlineData("name"," ")]
        [InlineData(" ","name")]
        [InlineData("nam","n ")]
        [InlineData(" name","n")]
        [Theory]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname)
        {
            UpdateAuthorQuery command = new UpdateAuthorQuery(null);
            command.Model= new UpdateAuthorModel(){Name = name,SurName = surname};

            UpdateAuthorQueryValidator validations = new UpdateAuthorQueryValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("absa","absa")]
        [InlineData("abasaa","aba")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldNotBeReturnErrors(string name, string surname)
        {
            UpdateAuthorQuery command = new UpdateAuthorQuery(null);
            command.Model= new UpdateAuthorModel(){Name = name,SurName = surname};
            
            UpdateAuthorQueryValidator validations = new UpdateAuthorQueryValidator();
            var result = validations.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}