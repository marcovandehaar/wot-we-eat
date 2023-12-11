using WotWeEat.Domain.Enum;

namespace WotWeEat.Domain;

public class MealOption
{
    public MealOption()
    {
        Vegetables = new List<Vegetable>();
        PossibleMeatFishes = new List<MeatFish>();
        PossibleVariations = new List<MealVariation>();
        InSeasons = new List<Season>();
    }

    public Guid MealOptionId { get; set; }
    public string? Description { get; set; }
    public MealBase? MealBase { get; set; }
    public bool SuitableForChildren { get; set; }
    public int? AmountOfWork { get; set; }
    public Healthy? Healthy { get; set; }

    public List<Vegetable> Vegetables { get; set; }
    public List<MeatFish> PossibleMeatFishes { get; set; }
    public List<MealVariation> PossibleVariations { get; set; }
    public List<Season> InSeasons { get; set; }
    public bool Active {get; set; }
}