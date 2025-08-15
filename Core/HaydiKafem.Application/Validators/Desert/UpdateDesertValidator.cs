using FluentValidation;
using HaydiKafem.Application.Dtos.DesertDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaydiKafem.Application.Validators.Desert
{
    public class UpdateDesertValidator : AbstractValidator<UpdateDesertDto>
    {
        //public int DesertId { get; set; }
        //public string DesertName { get; set; }
        //public string DesertImageUrl { get; set; }
        //public decimal DesertPrice { get; set; }
        //public string Description { get; set; }
        public UpdateDesertValidator()
        {
            RuleFor(x => x.DesertName).NotEmpty().WithMessage("Tatlı ismi boş geçilemez")
                .Length(3, 15).WithMessage("Tatlı ismi 3 ile 15 karakter arasında olmalıdır.");
            RuleFor(x => x.DesertImageUrl).NotEmpty().WithMessage("Tatlı resmi boş geçilemez.");
        }
    }
}
