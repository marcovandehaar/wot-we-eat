using System.ComponentModel.DataAnnotations.Schema;

namespace WotWeEat.DataAccess.EFCore.Model;

public class MealVariation
{
    public Guid MealVariationId { get; set; }
    public string Description { get; set; }
    public MealOption MealOption { get; set; }
    public Guid? MealOptionId { get; set; }
}