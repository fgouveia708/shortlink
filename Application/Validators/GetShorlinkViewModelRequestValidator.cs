using FluentValidation;

namespace Application.ViewModels
{
    public class GetShorlinkViewModelRequestValidator : AbstractValidator<GetShorlinkViewModelRequest>
    {
        public GetShorlinkViewModelRequestValidator()
        {
            RuleFor(x => x.ShortUrl).NotEmpty().WithMessage("Informe a url.");
        }
    }
}
