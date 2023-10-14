using System.ComponentModel.DataAnnotations.Schema;
using WotWeEat.Domain.Enum;

namespace WotWeEat.DataAccess.EFCore.Model;

public class MealOption
{
    public Guid MealOptionId { get; set; }
    public string Description { get; set; }
    public MealBase MealBase { get; set; }
    public bool SuitableForChildren { get; set; }
    public AmountOfWork AmountOfWork { get; set; }
    public Healthy Healthy { get; set; }

    public List<Vegetable> Vegetables { get; set; }
    public List<MeatFish> MeatFish { get; set; }
    [ForeignKey(nameof(MealVariation.MealOptionId))]
    public List<MealVariation> PossibleVariations { get; set; }
    public Guid MeatFishId { get; set; }
}