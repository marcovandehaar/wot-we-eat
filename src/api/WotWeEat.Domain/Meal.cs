using WotWeEat.Domain.Enum;

namespace WotWeEat.Domain;

public class Meal
{
    public Meal()
    {
        MeatFishes = new List<MeatFish>();
    }

    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public MealRating? Rating { get; set; }
    public bool WithChildren { get; set; }

    // Relationships
    public MealOption? MealOption { get; set; }
    public MealVariation? Variation { get; set; }
    public ICollection<MeatFish> MeatFishes { get; set; }

    public SuggestionStatus SuggestionStatus { get; set; }

}