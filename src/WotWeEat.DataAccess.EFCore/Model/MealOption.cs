using System.ComponentModel.DataAnnotations.Schema;
using WotWeEat.Domain.Enum;

namespace WotWeEat.DataAccess.EFCore.Model;

public class MealOption
{
    public MealOption()
    {
        Vegetables = new List<Vegetable>();
        PossibleVariations = new List<MealVariation>();
        MeatFishes = new List<MeatFish>();
    }

    public Guid MealOptionId { get; set; }
    public string? Description { get; set; }
    public MealBase MealBase { get; set; }
    public bool SuitableForChildren { get; set; }
    public AmountOfWork AmountOfWork { get; set; }
    public Healthy Healthy { get; set; }
    [ForeignKey(nameof(MealVariation.MealOptionId))]
    public ICollection<MealVariation> PossibleVariations { get; set; }
    public ICollection<Vegetable> Vegetables { get; set; }
    public ICollection<MeatFish> MeatFishes { get; set; }

}