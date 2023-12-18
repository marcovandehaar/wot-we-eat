using WotWeEat.DataAccess.EFCore.Model;
using WotWeEat.Domain.Enum;
using Xunit;

namespace WotWeEat.DataAccess.EFCore.Test;

public class AutomapperTest
{
    [Fact]
    public void Mapping_DomainToEF_ShouldBeValid()
    {
        // Arrange
        var domainModel = GetPizza();


        var config = new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        var mapper = config.CreateMapper();

        // Act
        var efModel = mapper.Map<Domain.MealOption, MealOption>(domainModel);

        // Assert
        Assert.Multiple(() =>
            {
                Assert.NotNull(efModel);
                Assert.Equal(efModel.AmountOfWork, domainModel.AmountOfWork); 
                Assert.Equal(efModel.Description, domainModel.Description);
                Assert.True(efModel.InSeasons.GetValueOrDefault().HasFlag(Season.spring));
                Assert.True(efModel.InSeasons.GetValueOrDefault().HasFlag(Season.summer));
                Assert.True(efModel.InSeasons.GetValueOrDefault().HasFlag(Season.spring));
                Assert.True(efModel.InSeasons.GetValueOrDefault().HasFlag(Season.Winter));
                Assert.Equal(efModel.Healthy, domainModel.Healthy); 
                Assert.Equal(efModel.MealBase, domainModel.MealBase); 
                Assert.Equal(efModel.MealOptionId, domainModel.MealOptionId); 
                Assert.Equal(efModel.PossibleMeatFishes.Count, domainModel.PossibleMeatFishes.Count); 
                Assert.Equal(efModel.PossibleMeatFishes.First().Name, domainModel.PossibleMeatFishes.First().Name); 
                Assert.Equal(efModel.PossibleMeatFishes.First().MeatFishId, domainModel.PossibleMeatFishes.First().MeatFishId); 
                Assert.Equal(efModel.PossibleMeatFishes.First().Type, domainModel.PossibleMeatFishes.First().Type);
                Assert.Equal(efModel.SuitableForChildren, domainModel.SuitableForChildren);
                Assert.Equal(efModel.PossibleVariations.Count, domainModel.PossibleVariations.Count);
                Assert.Equal(efModel.PossibleVariations.First().Description, domainModel.PossibleVariations.First().Description);
                Assert.Equal(efModel.PossibleVariations.First().MakeSuitableForKids, domainModel.PossibleVariations.First().MakeSuitableForKids);
                Assert.Equal(efModel.PossibleVariations.First().MealVariationId ,domainModel.PossibleVariations.First().MealVariationId);
                Assert.Equal(efModel.Vegetables.Count, domainModel.Vegetables.Count);
                Assert.Equal(efModel.Vegetables.First().Name, domainModel.Vegetables.First().Name);
                Assert.Equal(efModel.Vegetables.First().VegetableId, domainModel.Vegetables.First().VegetableId);
            }
        );
        
        
        
        // Add more assertions to validate properties
    }

    private static Domain.MealOption GetPizza()
    {
        var domainModel = new Domain.MealOption
        {
            AmountOfWork = 8,
            Description = "Zelfgemaakte Pizza",
            Healthy = Healthy.Unhealthy,
            MealBase = MealBase.Dough,
            MealOptionId = Guid.NewGuid(),
            InSeasons = new List<Season>(){Season.Autumn, Season.spring,Season.summer,  Season.Winter},
            PossibleMeatFishes = new List<Domain.MeatFish>()
            {
                new Domain.MeatFish()
                {
                    MeatFishId = Guid.NewGuid(),
                    Name = "Salami",
                    Type = MeatFishType.Meat
                }
            },
            SuitableForChildren = true,
            Vegetables = new List<Domain.Vegetable>()
            {
                new Domain.Vegetable()
                {
                    VegetableId = Guid.NewGuid(),
                    Name = "Champignons"
                }
            },
            PossibleVariations = new
                List<Domain.MealVariation>()
                {
                    new Domain.MealVariation()
                    {
                        Description = "Van de BBQ!",
                        MakeSuitableForKids = true,
                        MealVariationId = Guid.NewGuid()
                    }
                }
        };
        return domainModel;
    }
}
