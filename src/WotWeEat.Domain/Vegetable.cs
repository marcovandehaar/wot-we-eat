﻿namespace WotWeEat.Domain;

public class Vegetable
{
    public Guid ReferenceId { get; set; }
    public string Name { get; set; }
    public IEnumerable<MealOption> MealOptions { get; set; }
}