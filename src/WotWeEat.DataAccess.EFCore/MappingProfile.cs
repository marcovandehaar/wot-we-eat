using AutoMapper;
using DomainModel = WotWeEat.Domain ; // Adjust to your actual namespace
using EFModel = WotWeEat.DataAccess.EFCore.Model;

namespace WotWeEat.DataAccess.EFCore;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Map from domain to EFCore
        CreateMap<DomainModel.MealOption, EFModel.MealOption>().ReverseMap();
        CreateMap<DomainModel.Vegetable, EFModel.Vegetable>().ReverseMap();
        CreateMap<DomainModel.MeatFish, EFModel.MeatFish>().ReverseMap();
        CreateMap<DomainModel.MealVariation, EFModel.MealVariation>().ReverseMap();
        CreateMap<DomainModel.Meal, EFModel.Meal>().ReverseMap();
        CreateMap<DomainModel.MealSuggestion, EFModel.MealSuggestion>().ReverseMap();
    }
}