namespace WotWeEat.DataAccess.EFCore.Model
{
    public class MealOptionMeatFish
    {

        public MealOptionMeatFish(Guid mealOptionId, MealOption mealOption, Guid meatFishId, MeatFish meatFish)
        {
            MealOptionId = mealOptionId;
            MealOption = mealOption;
            MeatFishId = meatFishId;
            MeatFish = meatFish;
        }

        public Guid MealOptionId { get; set; }
        public MealOption? MealOption { get; set; }
        public Guid MeatFishId { get; set; }
        public MeatFish? MeatFish { get; set; }
    }
}
