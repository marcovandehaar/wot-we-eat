using AutoMapper;
using DomainModel = WotWeEat.Domain ; // Adjust to your actual namespace
using EFModel = WotWeEat.DataAccess.EFCore.Model;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Map from domain to EFCore
        CreateMap<DomainModel.MealOption, EFModel.MealOption>();
        CreateMap<DomainModel.Vegetable, EFModel.Vegetable>();
        CreateMap<DomainModel.MeatFish, EFModel.MeatFish>();
        CreateMap<DomainModel.MealVariation, EFModel.MealVariation>();
        CreateMap<DomainModel.Meal, EFModel.Meal>();
        CreateMap<DomainModel.MealSuggestion, EFModel.MealSuggestion>();

        // Map from EFCore to domain
        CreateMap<EFModel.MealOption, DomainModel.MealOption>();
        CreateMap<EFModel.Vegetable, DomainModel.Vegetable>();
        CreateMap<EFModel.MeatFish, DomainModel.MeatFish>();
        CreateMap<EFModel.MealVariation, DomainModel.MealVariation>();
        CreateMap<EFModel.Meal, DomainModel.Meal>();
        CreateMap<EFModel.MealSuggestion, DomainModel.MealSuggestion>();
    }
}