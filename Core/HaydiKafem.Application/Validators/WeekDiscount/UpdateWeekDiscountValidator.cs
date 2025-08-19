using FluentValidation;
using HaydiKafem.Application.Dtos.WeekDiscountDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaydiKafem.Application.Validators.WeekDiscount
{
    public class UpdateWeekDiscountValidator:AbstractValidator<UpdateWeekDiscountDto>
    {
        //public int WeekDiscountId { get; set; }
        //public string DiscountDay { get; set; }
        //public string DiscountPercent { get; set; }
        public UpdateWeekDiscountValidator()
        {
            RuleFor(x => x.DiscountDay).NotEmpty().WithMessage("İndirim günü boş geçilemez.");
            RuleFor(x => x.DiscountPercent).NotEmpty().WithMessage("İndirim Oranı boş geçilemez.");
        }
    }
}
