using FluentValidation;
using HaydiKafem.Application.Dtos.CarouselDtos;

namespace HaydiKafem.Application.Validators.Carousel
{
    public class CreateCarouselValidator : AbstractValidator<CreateCarouselDto>
    {
        //public string RestourantName { get; set; }
        //public string ImageUrl { get; set; }
        //public string Description { get; set; }
        public CreateCarouselValidator()
        {
            RuleFor(x => x.RestourantName).NotEmpty().WithMessage("Restorant ismi boş geçilemez.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Fotoğraf Url boş geçilemez.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez.")
                .Length(5, 200).WithMessage("Açıklama uzunluğu 5 ile 200 karakter arasında olmalıdır.");
        }
    }
}
