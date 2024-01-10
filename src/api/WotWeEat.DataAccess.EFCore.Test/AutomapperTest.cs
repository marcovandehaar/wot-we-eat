using WotWeEat.DataAccess.EFCore.Model;
using WotWeEat.Domain.Enum;
using Xunit;

namespace WotWeEat.DataAccess.EFCore.Test;

public class AutomapperTest
{
    [Fact]
    public void Mapping_DomainToEF_MealOption_ShouldBeValid()
    {
        // Arrange
        var domainMealOption = GetPizza();

        var config = new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        var mapper = config.CreateMapper();

        // Act
        var efMealOption = mapper.Map<Domain.MealOption, MealOption>(domainMealOption);

        // Assert
        Assert.Multiple(() =>
            {
                Assert.NotNull(efMealOption);
                Assert.Equal(efMealOption.AmountOfWork, domainMealOption.AmountOfWork); 
                Assert.Equal(efMealOption.Description, domainMealOption.Description);
                Assert.True(efMealOption.InSeasons.GetValueOrDefault().HasFlag(Season.Spring));
                Assert.True(efMealOption.InSeasons.GetValueOrDefault().HasFlag(Season.Summer));
                Assert.True(efMealOption.InSeasons.GetValueOrDefault().HasFlag(Season.Spring));
                Assert.True(efMealOption.InSeasons.GetValueOrDefault().HasFlag(Season.Winter));
                Assert.Equal(efMealOption.Healthy, domainMealOption.Healthy); 
                Assert.Equal(efMealOption.MealBase, domainMealOption.MealBase); 
                Assert.Equal(efMealOption.Id, domainMealOption.Id); 
                Assert.Equal(efMealOption.PossibleMeatFishes.Count, domainMealOption.PossibleMeatFishes.Count); 
                Assert.Equal(efMealOption.PossibleMeatFishes.First().Name, domainMealOption.PossibleMeatFishes.First().Name); 
                Assert.Equal(efMealOption.PossibleMeatFishes.First().Id, domainMealOption.PossibleMeatFishes.First().Id); 
                Assert.Equal(efMealOption.PossibleMeatFishes.First().Type, domainMealOption.PossibleMeatFishes.First().Type);
                Assert.Equal(efMealOption.SuitableForChildren, domainMealOption.SuitableForChildren);
                Assert.Equal(efMealOption.PossibleVariations.Count, domainMealOption.PossibleVariations.Count);
                Assert.Equal(efMealOption.PossibleVariations.First().Description, domainMealOption.PossibleVariations.First().Description);
                Assert.Equal(efMealOption.PossibleVariations.First().MakeSuitableForKids, domainMealOption.PossibleVariations.First().MakeSuitableForKids);
                Assert.Equal(efMealOption.PossibleVariations.First().Id ,domainMealOption.PossibleVariations.First().Id);
                Assert.Equal(efMealOption.Vegetables.Count, domainMealOption.Vegetables.Count);
                Assert.Equal(efMealOption.Vegetables.First().Name, domainMealOption.Vegetables.First().Name);
                Assert.Equal(efMealOption.Vegetables.First().Id, domainMealOption.Vegetables.First().Id);
            }
        );


    }

    [Fact]
    public void Mapping_DomainToEF_Meal_ShouldBeValid()
    {
        // Arrange
        var domainMeal = GetMeal(GetPizza());

        var config = new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        var mapper = config.CreateMapper();

        // Act
        var efMeal = mapper.Map<Domain.Meal, Meal>(domainMeal);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.NotNull(efMeal);
            Assert.Equal(efMeal.Id, domainMeal.Id);
            Assert.Equal(efMeal.Date, domainMeal.Date);
            Assert.Equal(efMeal.Rating, domainMeal.Rating);
            Assert.Equal(efMeal.WithChildren, domainMeal.WithChildren);
            Assert.Equal(efMeal.SuggestionStatus, domainMeal.SuggestionStatus);

            Assert.Equal(efMeal.MealOption.Id, domainMeal.MealOption.Id);
            Assert.Equal(efMeal.MeatFishes.Count, domainMeal.MeatFishes.Count);
        });
    }

    private static Domain.Meal GetMeal(Domain.MealOption option)
    {
        var domainModel = new Domain.Meal()
        {
            MealOption = option,
            SuggestionStatus = SuggestionStatus.Approved,
            Date = new DateTime(2024, 1, 1),
            Id = Guid.NewGuid(),
            MeatFishes = new[]
            {
                option.PossibleMeatFishes.First()
            }
        };
        return domainModel;
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
