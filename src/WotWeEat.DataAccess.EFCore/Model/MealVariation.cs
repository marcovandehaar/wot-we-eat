using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WotWeEat.DataAccess.EFCore.Model;

public class MealVariation
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid MealVariationId { get; set; }
    public string? Description { get; set; }
    public MealOption? MealOption { get; set; }
    public Guid? MealOptionId { get; set; }
    public bool MakeSuitableForKids { get; set; }
}