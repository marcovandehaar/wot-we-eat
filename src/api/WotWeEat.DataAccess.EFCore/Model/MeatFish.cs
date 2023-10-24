using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WotWeEat.Domain.Enum;

namespace WotWeEat.DataAccess.EFCore.Model;

public class MeatFish
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid MeatFishId { get; set; }
    public string? Name { get; set; }
    
    public MeatFishType Type { get; set; }
    public ICollection<MealOption>? MealOptions { get; set; }
}