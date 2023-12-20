﻿using WotWeEat.Domain.Enum;

namespace WotWeEat.Domain;

public class MeatFish
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public MeatFishType Type { get; set; }
}