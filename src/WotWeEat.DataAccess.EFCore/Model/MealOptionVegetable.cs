

namespace WotWeEat.DataAccess.EFCore.Model
{
    internal class MealOptionVegetable
    {

        public Guid MealOptionId { get; set; }
        public MealOption? MealOption { get; set; }
        public Guid VegetableId { get; set; }
        public Vegetable? Vegetable { get; set; }
    }
}

