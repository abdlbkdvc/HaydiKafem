using FluentValidation;
using HaydiKafem.Application.Dtos.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaydiKafem.Application.Validators.Food
{
    public class CreateFoodValidator : AbstractValidator<CreateFoodDto>
    {
        public CreateFoodValidator()
        {
            RuleFor(x => x.FoodName).NotEmpty().WithMessage("Yemek ismi boş geçilemez.")
                .Length(3, 30).WithMessage("Yemek ismi 3 ile 30 karakter arasında olmalıdır.");

            RuleFor(x => x.FoodImageUrl).NotEmpty().WithMessage("Yemek fotoğrafı boş geçilemez.");

            RuleFor(x => x.FoodPrice).NotEmpty().WithMessage("Yemek ücreti boş geçilemez.")
                .GreaterThan(0).WithMessage("Yemek ücreti sıfırdan büyük olmalıdır.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Yemek açıklaması boş geçilemez.")
                .Length(5, 200).WithMessage("Yemek açıklaması 5 ile 200 karakter arasında olmalıdır.");
        }
    }
}
