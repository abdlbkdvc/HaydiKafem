using FluentValidation;
using HaydiKafem.Application.Dtos.TestimonialDtos;

namespace HaydiKafem.Application.Validators.Testimonial
{
    public class UpdateTestimonialValidator : AbstractValidator<UpdateTestimonialDto>
    {
        //public string Comment { get; set; }
        //public string NameSurname { get; set; }
        //public string Job { get; set; }
        //public string ImageUrl { get; set; }
        public UpdateTestimonialValidator()
        {
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorum kısmı boş geçilemez.")
                .Length(5, 300).WithMessage("yorum kısmı 5 ile 300 karakter arasında olmalıdır.");
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad ve soyad kısmı boş geçilemez.");
            RuleFor(x => x.Job).NotEmpty().WithMessage("Meslek kısmı boş geçilemez.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Fotoğraf Url kısmı boş geçilemez.");
        }
    }
}
