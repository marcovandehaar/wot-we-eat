﻿namespace WotWeEat.Domain;

public class Vegetable
{
    public Guid VegetableId { get; set; }
    public string Name { get; set; }
    public IEnumerable<MealOption> MealOptions { get; set; }
}