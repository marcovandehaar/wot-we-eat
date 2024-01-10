using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WotWeEat.Domain.Enum;

namespace WotWeEat.DataAccess.EFCore.Model;

public class Meal
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public MealRating? Rating { get; set; }
    public bool WithChildren { get; set; }

    // Relationships
    public Guid MealOptionId { get; set; }
    public MealOption? MealOption { get; set; }
    public ICollection<MeatFish> MeatFishes { get; set; }

    public Guid? MealVariationId { get; set; }
    public MealVariation? Variation { get; set; }
    public SuggestionStatus SuggestionStatus { get; set; }

}