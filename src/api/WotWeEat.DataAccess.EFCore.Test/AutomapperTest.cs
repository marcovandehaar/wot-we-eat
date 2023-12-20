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
                Assert.True(efModel.InSeasons.GetValueOrDefault().HasFlag(Season.Spring));
                Assert.True(efModel.InSeasons.GetValueOrDefault().HasFlag(Season.Summer));
                Assert.True(efModel.InSeasons.GetValueOrDefault().HasFlag(Season.Spring));
                Assert.True(efModel.InSeasons.GetValueOrDefault().HasFlag(Season.Winter));
                Assert.Equal(efModel.Healthy, domainModel.Healthy); 
                Assert.Equal(efModel.MealBase, domainModel.MealBase); 
                Assert.Equal(efModel.Id, domainModel.Id); 
                Assert.Equal(efModel.PossibleMeatFishes.Count, domainModel.PossibleMeatFishes.Count); 
                Assert.Equal(efModel.PossibleMeatFishes.First().Name, domainModel.PossibleMeatFishes.First().Name); 
                Assert.Equal(efModel.PossibleMeatFishes.First().Id, domainModel.PossibleMeatFishes.First().Id); 
                Assert.Equal(efModel.PossibleMeatFishes.First().Type, domainModel.PossibleMeatFishes.First().Type);
                Assert.Equal(efModel.SuitableForChildren, domainModel.SuitableForChildren);
                Assert.Equal(efModel.PossibleVariations.Count, domainModel.PossibleVariations.Count);
                Assert.Equal(efModel.PossibleVariations.First().Description, domainModel.PossibleVariations.First().Description);
                Assert.Equal(efModel.PossibleVariations.First().MakeSuitableForKids, domainModel.PossibleVariations.First().MakeSuitableForKids);
                Assert.Equal(efModel.PossibleVariations.First().Id ,domainModel.PossibleVariations.First().Id);
                Assert.Equal(efModel.Vegetables.Count, domainModel.Vegetables.Count);
                Assert.Equal(efModel.Vegetables.First().Name, domainModel.Vegetables.First().Name);
                Assert.Equal(efModel.Vegetables.First().Id, domainModel.Vegetables.First().Id);
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
            Id = Guid.NewGuid(),
            InSeasons = new List<Season>(){Season.Autumn, Season.Spring,Season.Summer,  Season.Winter},
            PossibleMeatFishes = new List<Domain.MeatFish>()
            {
                new Domain.MeatFish()
                {
                    Id = Guid.NewGuid(),
                    Name = "Salami",
                    Type = MeatFishType.Meat
                }
            },
            SuitableForChildren = true,
            Vegetables = new List<Domain.Vegetable>()
            {
                new Domain.Vegetable()
                {
                    Id = Guid.NewGuid(),
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
                        Id = Guid.NewGuid()
                    }
                }
        };
        return domainModel;
    }
}
