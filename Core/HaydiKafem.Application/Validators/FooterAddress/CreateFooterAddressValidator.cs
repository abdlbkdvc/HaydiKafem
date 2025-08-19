using FluentValidation;
using HaydiKafem.Application.Dtos.FooterAddressDtos;

namespace HaydiKafem.Application.Validators.FooterAddress
{
    public class CreateFooterAddressValidator : AbstractValidator<CreateFooterAddressDto>
    {
        public CreateFooterAddressValidator()
        {
            RuleFor(x => x.Location).NotEmpty().WithMessage("Lokasyon boş geçilemez.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez.")
                .Length(5, 200).WithMessage("Açıklama 5 ile 200 karakter arasında olmalıdır.");
            RuleFor(x => x.FacebookUrl).NotEmpty().WithMessage("Facebook Url boş geçilemez.");
            RuleFor(x => x.TwitterUrl).NotEmpty().WithMessage("Twitter Url boş geçilemez.");
            RuleFor(x => x.LinkedInUrl).NotEmpty().WithMessage("LinkedIn Url boş geçilemez.");
            RuleFor(x => x.InstagramUrl).NotEmpty().WithMessage("Instagram Url boş geçilemez.");
            RuleFor(x => x.PinterestUrl).NotEmpty().WithMessage("Pinterest Url boş geçilemez.");
        }
    }
}
