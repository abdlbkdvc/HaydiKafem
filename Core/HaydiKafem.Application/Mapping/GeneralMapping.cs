using AutoMapper;
using HaydiKafem.Application.Dtos.ColdDrinkDtos;
using HaydiKafem.Application.Dtos.DesertDtos;
using HaydiKafem.Application.Dtos.Food;
using HaydiKafem.Application.Dtos.HotDrinkDtos;
using HaydiKafem.Application.Dtos.IceCreamDtos;
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

        }
    }
}
