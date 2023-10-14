using WotWeEat.Domain.Enum;

namespace WotWeEat.DataAccess.EFCore.Model;

public class Meal
{
    
    public Guid MealId { get; set; }
    public DateTime Date { get; set; }
    public MealRating Rating { get; set; }
    public bool WithChildren { get; set; }

    // Relationships
    public MealOption MealOption { get; set; }
    public MealVariation Variation { get; set; }
}