using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WotWeEat.Domain;
using MealOption = WotWeEat.DataAccess.EFCore.Model.MealOption;
using Vegetable = WotWeEat.DataAccess.EFCore.Model.Vegetable;

namespace WotWeEat.DataAccess.EFCore;

public class WotWeEatDbContext: DbContext
{
    public WotWeEatDbContext(DbContextOptions<WotWeEatDbContext> options)
        : base(options)
    {
    }

    public DbSet<MealOption> MealOptions { get; set; }
    public DbSet<Vegetable> Vegetables { get; set; }
    // Define DbSet for other domain objects

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Fluent API mappings here
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
