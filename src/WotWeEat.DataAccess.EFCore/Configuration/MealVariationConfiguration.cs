using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WotWeEat.Domain;

namespace WotWeEat.DataAccess.EFCore.Configuration;

public class MealVariationConfiguration : IEntityTypeConfiguration<MealVariation>
{
    public void Configure(EntityTypeBuilder<MealVariation> builder)
    {
        builder.ToTable("MealVariations");
        builder.HasKey(mv => mv.ReferenceId);
        builder.Property(mv => mv.Description).IsRequired();
    }
}