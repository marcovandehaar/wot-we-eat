using WotWeEat.Domain.Enum;

namespace WotWeEat.Domain;

public class MealOption
{
    public Guid ReferenceId { get; set; }
    public string Description { get; set; }
    public MealBase MealBase { get; set; }
    public bool SuitableForChildren { get; set; }
    public AmountOfWork AmountOfWork { get; set; }
    public Healthy Healthy { get; set; }

    public List<Vegetable> Vegetables { get; set; }
    public MeatFish? MeatFish { get; set; }
    public List<MealVariation> PossibleVariations { get; set; }
    public Guid MeatFishId { get; set; }
}