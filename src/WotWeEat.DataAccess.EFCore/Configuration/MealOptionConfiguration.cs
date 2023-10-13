using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WotWeEat.Domain;

namespace WotWeEat.DataAccess.EFCore.Configuration
{
    public class MealOptionConfiguration : IEntityTypeConfiguration<MealOption>
    {
        public void Configure(EntityTypeBuilder<MealOption> builder)
        {
            builder.ToTable("MealOptions");
            builder.HasKey(mo => mo.ReferenceId);
            builder.Property(mo => mo.Description).IsRequired();
            builder.Property(mo => mo.SuitableForChildren).IsRequired();
            builder.Property(mo => mo.AmountOfWork).IsRequired();
            builder.Property(mo => mo.Healthy).IsRequired();

            builder.Property(mo => mo.MeatFishId).IsRequired();
            builder.HasOne(mo => mo.MeatFish)
                .WithOne()
                .HasForeignKey<MealOption>(mo => mo.MeatFishId);

            builder.HasMany(mo => mo.PossibleVariations)
                .WithOne()
                .HasForeignKey(mv => mv.MealOptionId);

            builder.HasMany(e => e.Vegetables)
                .WithMany(e => e.MealOptions)
                .UsingEntity(
                    "MealOptionVegetable",
                    l => l.HasOne(typeof(Vegetable)).WithMany().HasForeignKey("VegetableReferenceId").HasPrincipalKey(nameof(Vegetable.ReferenceId)),
                    r => r.HasOne(typeof(MealOption)).WithMany().HasForeignKey("MealOptionReferenceIdId").HasPrincipalKey(nameof(MealOption.ReferenceId)),
                    j => j.HasKey("VegetableReferenceId", "MealOptionReferenceIdId"));
        }
    }
}
