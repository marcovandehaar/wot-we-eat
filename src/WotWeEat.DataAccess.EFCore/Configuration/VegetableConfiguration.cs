using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WotWeEat.Domain;

namespace WotWeEat.DataAccess.EFCore.Configuration;

public class VegetableConfiguration : IEntityTypeConfiguration<Vegetable>
{
    public void Configure(EntityTypeBuilder<Vegetable> builder)
    {
        builder.ToTable("Vegetables");
        builder.HasKey(v => v.ReferenceId);
        builder.Property(v => v.Name).IsRequired();
    }
}