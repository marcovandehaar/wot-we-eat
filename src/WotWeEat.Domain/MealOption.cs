﻿using WotWeEat.Domain.Enum;

namespace WotWeEat.Domain;

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
    public List<MealVariation> PossibleVariations { get; set; }
}