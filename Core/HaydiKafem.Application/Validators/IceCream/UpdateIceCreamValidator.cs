using FluentValidation;
using HaydiKafem.Application.Dtos.IceCreamDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaydiKafem.Application.Validators.IceCream
{
    public class UpdateIceCreamValidator:AbstractValidator<UpdateIceCreamDto>
    {
        public UpdateIceCreamValidator()
        {
            RuleFor(x => x.IceCreamName).NotEmpty().WithMessage("Dondurma ismi boş geçilemez.")
               .Length(3, 30).WithMessage("Dondurma ismi 3 ile 30 karakter arasında olmalıdır.");

            RuleFor(x => x.IceCreamImageUrl).NotEmpty().WithMessage("Dondurma fotoğrafı boş geçilemez.");

            RuleFor(x => x.IceCreamPrice).NotEmpty().WithMessage("Dondurma ücreti boş geçilemez.")
                .GreaterThan(0).WithMessage("Dondurma ücreti sıfırdan büyük olmalıdır.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Dondurma açıklaması boş geçilemez.")
                .Length(5, 200).WithMessage("Dondurma açıklaması 5 ile 200 karakter arasında olmalıdır.");
        }
    }
}
