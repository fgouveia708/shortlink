using Application.ViewModels;
using FluentValidation;

namespace Application.Validators
{
    public class CreateShortlinkViewModelRequestValidator : AbstractValidator<CreateShortlinkViewModelRequest>
    {
        public CreateShortlinkViewModelRequestValidator()
        {
            RuleFor(x => x.Url).NotEmpty().WithMessage("Informe a url de destino.");
        }
    }
}
