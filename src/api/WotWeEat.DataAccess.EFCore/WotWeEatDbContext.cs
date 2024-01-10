using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WotWeEat.DataAccess.EFCore.Model;
using WotWeEat.DataAccess.EFCore.Seed;

namespace WotWeEat.DataAccess.EFCore;

public class WotWeEatDbContext: DbContext
{
    public WotWeEatDbContext(DbContextOptions<WotWeEatDbContext> options)
        : base(options)
    {
    }

    public DbSet<MealOption> MealOption { get; set; }
    public DbSet<Vegetable> Vegetable { get; set; }
    public DbSet<MeatFish> MeatFish { get; set; }
    public DbSet<MealVariation> MealVariation { get; set; }
    public DbSet<Meal> Meal{ get; set; }
    // Define DbSet for other domain objects

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Fluent API mappings here
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<MeatFish>()
            .HasAlternateKey(a => new { a.Name });
        modelBuilder.Entity<Vegetable>()
            .HasAlternateKey(a => new { a.Name });


        modelBuilder.SeedVegetables();
        modelBuilder.SeedMeatFishes();
    }

    public void SetEntityState<TEntity>(TEntity entity, EntityState state) where TEntity : class
    {
        Entry(entity).State = state;
    }

    
}
