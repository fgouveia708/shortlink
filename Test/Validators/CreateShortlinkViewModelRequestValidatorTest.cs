using Application.Validators;
using Application.ViewModels;
using FluentValidation.TestHelper;
using Xunit;
using Xunit.Priority;

namespace Test.Validators
{
    public class CreateShortlinkViewModelRequestValidatorTest
    {
        [Fact(DisplayName = "Should have error when url is null"), Priority(1)]
        [Trait("Validator", "CreateShortlinkViewModelRequestValidator")]
        public void Should_Have_Error_When_Url_Is_Null()
        {
            var validator = new CreateShortlinkViewModelRequestValidator();
            var result = validator.TestValidate(new CreateShortlinkViewModelRequest());
            result.ShouldHaveValidationErrorFor(c => c.Url).WithErrorMessage("Informe a url de destino.");
        }
    }
}
