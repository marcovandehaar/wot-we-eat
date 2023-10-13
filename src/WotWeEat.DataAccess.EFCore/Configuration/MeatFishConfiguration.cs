using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WotWeEat.Domain;

namespace WotWeEat.DataAccess.EFCore.Configuration;

public class MeatFishConfiguration : IEntityTypeConfiguration<MeatFish>
{
    public void Configure(EntityTypeBuilder<MeatFish> builder)
    {
        builder.ToTable("MeatFish");
        builder.HasKey(mf => mf.ReferenceId);
        builder.Property(mf => mf.Name).IsRequired();
        builder.Property(mf => mf.Type).IsRequired();
    }
}