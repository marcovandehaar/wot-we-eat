using WotWeEat.DataAccess.EFCore.Model;
using Xunit;
using  Domain = WotWeEat.Domain;

namespace WotWeEat.DataAccess.EFCore.Test;

public class AutomapperTest
{
    [Fact]
    public void Mapping_DomainToEF_ShouldBeValid()
    {
        // Arrange
        var domainModel = new Domain.MealOption
        {
            // Set properties of the domain model for testing
        };

        var config = new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        var mapper = config.CreateMapper();

        // Act
        var efModel = mapper.Map<Domain.MealOption, MealOption>(domainModel);

        // Assert
        Assert.NotNull(efModel);
        // Add more assertions to validate properties
    }

}
