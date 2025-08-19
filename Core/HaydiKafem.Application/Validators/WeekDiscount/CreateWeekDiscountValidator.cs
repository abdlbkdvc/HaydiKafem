using FluentValidation;
using HaydiKafem.Application.Dtos.WeekDiscountDtos;

namespace HaydiKafem.Application.Validators.WeekDiscount
{
    public class CreateWeekDiscountValidator : AbstractValidator<CreateWeekDiscountDto>
    {
        public CreateWeekDiscountValidator()
        {
            RuleFor(x => x.DiscountDay).NotEmpty().WithMessage("İndirim günü boş geçilemez.");
            RuleFor(x => x.DiscountPercent).NotEmpty().WithMessage("İndirim Oranı boş geçilemez.");
        }
    }
}
