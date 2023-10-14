using WotWeEat.Domain.Enum;

namespace WotWeEat.DataAccess.EFCore.Model;

public class MeatFish
{
    public Guid MeatFishId { get; set; }
    public string Name { get; set; }
    public MeatFishType Type { get; set; }
}