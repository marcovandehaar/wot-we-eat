using AutoMapper;
using DomainModel = WotWeEat.Domain ; // Adjust to your actual namespace
using EFModel = WotWeEat.DataAccess.EFCore.Model;

namespace WotWeEat.DataAccess.EFCore;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Map from domain to EFCore. Just for the record. I know this is a terrible idea.
        // mapping from a domain to a data layer model using automapper gives all kinds of nasty problems
        // with EF's model tracking and can only be mostly solved using very ugly
        // dataacess code. I wanted to find out just how complex it would get
        // and whether in the end, it would still save me time....
        // it didn't, so the data layer is marked for refactoring, either by 
        // creating manual mapping code which takes entity state into account,
        // or by changing the storage to  a document store database, removing the
        // need for an ORM all together, but creating it's own (mostly smaller) challenges.
        CreateMap<DomainModel.MealOption, EFModel.MealOption>().ReverseMap();
        CreateMap<DomainModel.Vegetable, EFModel.Vegetable>().ReverseMap();
        CreateMap<DomainModel.MeatFish, EFModel.MeatFish>().ReverseMap();
        CreateMap<DomainModel.MealVariation, EFModel.MealVariation>().ReverseMap();
        CreateMap<DomainModel.Meal, EFModel.Meal>().ReverseMap();
        CreateMap<DomainModel.MealSuggestion, EFModel.MealSuggestion>().ReverseMap();
    }
}