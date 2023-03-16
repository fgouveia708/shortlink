using Application.ViewModels;
using FluentValidation.TestHelper;
using Xunit;
using Xunit.Priority;

namespace Test.Validators
{
    public class GetShorlinkViewModelRequestValidatorTest
    {
        [Fact(DisplayName = "Should have error when short url is null"), Priority(1)]
        [Trait("Validator", "GetShorlinkViewModelRequestValidator")]
        public void Should_Have_Error_When_Short_Url_Is_Null()
        {
            var validator = new GetShorlinkViewModelRequestValidator();
            var result = validator.TestValidate(new GetShorlinkViewModelRequest());
            result.ShouldHaveValidationErrorFor(c => c.ShortUrl).WithErrorMessage("Informe a url.");
        }
    }
}
