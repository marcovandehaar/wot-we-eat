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
                Assert.Equal(efModel.Healthy, domainModel.Healthy); 
                Assert.Equal(efModel.MealBase, domainModel.MealBase); 
                Assert.Equal(efModel.MealOptionId, domainModel.MealOptionId); 
                Assert.Equal(efModel.MeatFishes.Count, domainModel.MeatFishes.Count); 
                Assert.Equal(efModel.MeatFishes.First().Name, domainModel.MeatFishes.First().Name); 
                Assert.Equal(efModel.MeatFishes.First().MeatFishId, domainModel.MeatFishes.First().MeatFishId); 
                Assert.Equal(efModel.MeatFishes.First().Type, domainModel.MeatFishes.First().Type);
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
            AmountOfWork = AmountOfWork.LotOfWork,
            Description = "Zelfgemaakte Pizza",
            Healthy = Healthy.Unhealthy,
            MealBase = MealBase.Dough,
            MealOptionId = Guid.NewGuid(),
            MeatFishes = new List<Domain.MeatFish>()
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
