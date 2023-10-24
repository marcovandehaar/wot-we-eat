using WotWeEat.Domain.Enum;

namespace WotWeEat.Domain;

public class Meal
{

    public Guid MealId { get; set; }
    public DateTime Date { get; set; }
    public MealRating? Rating { get; set; }
    public bool WithChildren { get; set; }

    // Relationships
    public MealOption? MealOption { get; set; }
    public MealVariation? Variation { get; set; }
}