using FluentValidation;
using HaydiKafem.Application.Dtos.AboutDtos;

namespace HaydiKafem.Application.Validators.About
{
    public class CreateAboutValidator : AbstractValidator<CreateAboutDto>
    {
        public CreateAboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez.")
                  .Length(5, 25).WithMessage("Başlık karakter sayısı 5 ile 25 arasında olmalıdır.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez.")
                .Length(5, 200).WithMessage("Açıklama 5 ile 200 karakter arasında olmalıdır.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Fotoğraf Url boş geçilemez");
        }
    }
}
