using AutoMapper;
using HaydiKafem.Application.Dtos.AboutDtos;
using HaydiKafem.Application.Dtos.CarouselDtos;
using HaydiKafem.Application.Dtos.ColdDrinkDtos;
using HaydiKafem.Application.Dtos.DesertDtos;
using HaydiKafem.Application.Dtos.Food;
using HaydiKafem.Application.Dtos.FooterAddressDtos;
using HaydiKafem.Application.Dtos.HotDrinkDtos;
using HaydiKafem.Application.Dtos.IceCreamDtos;
using HaydiKafem.Application.Dtos.TestimonialDtos;
using HaydiKafem.Application.Dtos.WeekDiscountDtos;
using HaydiKafem.Domain.Entities;

namespace HaydiKafem.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Food, CreateFoodDto>().ReverseMap();
            CreateMap<Food, UpdateFoodDto>().ReverseMap();
            CreateMap<Food, GetByIdFoodDto>().ReverseMap();
            CreateMap<Food, ResultFoodDto>().ReverseMap();


            CreateMap<Desert, CreateDesertDto>().ReverseMap();
            CreateMap<Desert, ResultDesertDto>().ReverseMap();
            CreateMap<Desert, GetByIdDesertDto>().ReverseMap();
            CreateMap<Desert, UpdateDesertDto>().ReverseMap();

            CreateMap<HotDrink, CreateHotDrinkDto>().ReverseMap();
            CreateMap<HotDrink, ResultHotDrinkDto>().ReverseMap();
            CreateMap<HotDrink, GetByIdHotDrinkDto>().ReverseMap();
            CreateMap<HotDrink, UpdateHotDrinkDto>().ReverseMap();

            CreateMap<ColdDrink, CreateColdDrinkDto>().ReverseMap();
            CreateMap<ColdDrink, ResultColdDrinkDto>().ReverseMap();
            CreateMap<ColdDrink, GetByIdColdDrinkDto>().ReverseMap();
            CreateMap<ColdDrink, UpdateColdDrinkDto>().ReverseMap();

            CreateMap<IceCream, CreateIceCreamDto>().ReverseMap();
            CreateMap<IceCream, ResultIceCreamDto>().ReverseMap();
            CreateMap<IceCream, GetByIdIceCreamDto>().ReverseMap();
            CreateMap<IceCream, UpdateIceCreamDto>().ReverseMap();

            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetByIdAboutDto>().ReverseMap();

            CreateMap<Carousel, CreateCarouselDto>().ReverseMap();
            CreateMap<Carousel, ResultCarouselDto>().ReverseMap();
            CreateMap<Carousel, GetByIdCarouselDto>().ReverseMap();
            CreateMap<Carousel, UpdateCarouselDto>().ReverseMap();

            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetByIdTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();

            CreateMap<WeekDiscount, CreateWeekDiscountDto>().ReverseMap();
            CreateMap<WeekDiscount, ResultWeekDiscountDto>().ReverseMap();
            CreateMap<WeekDiscount, GetByIdWeekDiscountDto>().ReverseMap();
            CreateMap<WeekDiscount, UpdateWeekDiscountDto>().ReverseMap();

            CreateMap<FooterAddress, CreateFooterAddressDto>().ReverseMap();
            CreateMap<FooterAddress, ResultFooterAddressDto>().ReverseMap();
            CreateMap<FooterAddress, GetByIdFooterAddressDto>().ReverseMap();
            CreateMap<FooterAddress, UpdateFooterAddressDto>().ReverseMap();
        }
    }
}
