using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WotWeEat.Domain.Enum;

namespace WotWeEat.DataAccess.EFCore.Model;

public class MealOption
{
    public MealOption()
    {
        Vegetables = new List<Vegetable>();
        PossibleVariations = new List<MealVariation>();
        PossibleMeatFishes = new List<MeatFish>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public MealBase MealBase { get; set; }
    public bool SuitableForChildren { get; set; }
    public int? AmountOfWork { get; set; }
    public Healthy Healthy { get; set; }
    [ForeignKey(nameof(MealVariation.MealOptionId))]
    public ICollection<MealVariation> PossibleVariations { get; set; }
    public ICollection<Vegetable> Vegetables { get; set; }
    public ICollection<MeatFish> PossibleMeatFishes { get; set; }
    public Season? InSeasons { get; set; }
    public bool Active { get; set; }

}