using FluentValidation;
using HaydiKafem.Application.Dtos.FooterAddressDtos;

namespace HaydiKafem.Application.Validators.FooterAddress
{
    public class UpdateFooterAddressValidator : AbstractValidator<UpdateFooterAddressDto>
    {
        //public int FooterAddressId { get; set; }
        //public string Location { get; set; }
        //public string Email { get; set; }
        //public string Title { get; set; }
        //public string Description { get; set; }
        //public string FacebookUrl { get; set; }
        //public string TwitterUrl { get; set; }
        //public string LinkedInUrl { get; set; }
        //public string InstagramUrl { get; set; }
        //public string PinterestUrl { get; set; }
        public UpdateFooterAddressValidator()
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
