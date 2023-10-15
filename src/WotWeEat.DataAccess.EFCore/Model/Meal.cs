using System.ComponentModel.DataAnnotations.Schema;
using WotWeEat.Domain.Enum;

namespace WotWeEat.DataAccess.EFCore.Model;

[Table("Meal")]
public class Meal
{
    public Guid MealId { get; set; }
    public DateTime Date { get; set; }
    public MealRating? Rating { get; set; }
    public bool WithChildren { get; set; }

    // Relationships
    public Guid MealOptionId { get; set; }
    public MealOption? MealOption { get; set; }
    public Guid MealVariationId { get; set; }
    public MealVariation? Variation { get; set; }

}