using WotWeEat.Domain;
using Meal = WotWeEat.DataAccess.EFCore.Model.Meal;
using MealOption = WotWeEat.DataAccess.EFCore.Model.MealOption;
using MealVariation = WotWeEat.DataAccess.EFCore.Model.MealVariation;
using MeatFish = WotWeEat.DataAccess.EFCore.Model.MeatFish;
using Vegetable = WotWeEat.DataAccess.EFCore.Model.Vegetable;

namespace WotWeEat.DataAccess.EFCore;

public interface IWotWeEatRepository
{
    Task<MealOption?> GetMealOption(Guid mealOptionId);
    Task<Meal?> GetMeal(Guid meal);
    Task<List<MealOption>> GetAllMealOptions(bool? isActive = null);
    Task<MealOption> SaveMealOption(MealOption mealOption);
    Task<Meal> SaveMeal(Meal meal);
    Task<List<Vegetable>> GetAllVegetables();
    Task<List<MeatFish>> GetAllMeatFish();
    Task<MeatFish> SaveMeatFish(MeatFish meatFish);
    Task<MealVariation> SaveMealVariation(MealVariation mealVariation);
    Task<Vegetable> SaveVegetable(Vegetable vegetable);
    Task<Vegetable?> GetVegetableByName(string name);
    Task<MeatFish?> GetMeatFishByName(string name);
}
