﻿namespace WotWeEat.Domain;

public class MealVariation
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public bool MakeSuitableForKids { get; set; }
}