using FluentValidation;
using HaydiKafem.Application.Dtos.DesertDtos;

namespace HaydiKafem.Application.Validators.Desert
{
    public class CreateDesertValidator : AbstractValidator<CreateDesertDto>
    {
        public CreateDesertValidator()
        {
            RuleFor(x => x.DesertName).NotEmpty().WithMessage("Tatlı ismi boş geçilemez")
               .Length(3, 15).WithMessage("Tatlı ismi 3 ile 15 karakter arasında olmalıdır.");
            RuleFor(x => x.DesertImageUrl).NotEmpty().WithMessage("Tatlı resmi boş geçilemez.");
            RuleFor(x => x.DesertPrice).GreaterThan(0).WithMessage("Tatlı fiyatı sıfırdan büyük olmalıdır.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Tatlı açıklaması boş geçilemez.")
                .Length(5, 200).WithMessage("Tatlı açıklaması 5 ile 200 karakter arasında olmalıdır.");
        }
    }
}
