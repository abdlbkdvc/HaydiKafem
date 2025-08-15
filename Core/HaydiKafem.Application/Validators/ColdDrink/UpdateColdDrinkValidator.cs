using FluentValidation;
using HaydiKafem.Application.Dtos.ColdDrinkDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaydiKafem.Application.Validators.ColdDrink
{
    public class UpdateColdDrinkValidator : AbstractValidator<UpdateColdDrinkDto>
    {
        public UpdateColdDrinkValidator()
        {
            RuleFor(x => x.ColdDrinkName).NotEmpty().WithMessage("Soğuk içecek ismi boş geçilemez.")
               .Length(3, 30).WithMessage("Soğuk içecek ismi 3 ile 30 karakter arasında olmalıdır.");

            RuleFor(x => x.ColdDrinkImageUrl).NotEmpty().WithMessage("Soğuk içecek fotoğrafı boş geçilemez.");

            RuleFor(x => x.ColdDrinkPrice).NotEmpty().WithMessage("Soğuk içecek ücreti boş geçilemez.")
                .GreaterThan(0).WithMessage("Soğuk içecek ücreti sıfırdan büyük olmalıdır.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Soğuk içecek açıklaması boş geçilemez.")
                .Length(5, 200).WithMessage("Soğuk içecek açıklaması 5 ile 200 karakter arasında olmalıdır.");
        }
    }
}
