using FluentValidation;
using HaydiKafem.Application.Dtos.HotDrinkDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaydiKafem.Application.Validators.HotDrink
{
    public class CreateHotDrinkValidator : AbstractValidator<CreateHotDrinkDto>
    {
        public CreateHotDrinkValidator()
        {
            RuleFor(x => x.HotDrinkName).NotEmpty().WithMessage("Sıcak içecek ismi boş geçilemez.")
         .Length(3, 30).WithMessage("Sıcak içecek ismi 3 ile 30 karakter arasında olmalıdır.");

            RuleFor(x => x.HotDrinkImageUrl).NotEmpty().WithMessage("Sıcak içecek fotoğrafı boş geçilemez.");

            RuleFor(x => x.HotDrinkPrice).NotEmpty().WithMessage("Sıcak içecek ücreti boş geçilemez.")
                .GreaterThan(0).WithMessage("Sıcak içecek ücreti sıfırdan büyük olmalıdır.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Sıcak içecek açıklaması boş geçilemez.")
                .Length(5, 200).WithMessage("Sıcak içecek açıklaması 5 ile 200 karakter arasında olmalıdır.");
        }
    }
}
