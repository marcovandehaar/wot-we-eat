﻿namespace WotWeEat.Domain;

public class MealVariation
{
    public Guid MealVariationId { get; set; }
    public string Description { get; set; }
    public MealOption MealOption { get; set; }
}