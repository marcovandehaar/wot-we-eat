using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WotWeEat.Domain;

namespace WotWeEat.DataAccess.Interfaces
{
    public interface IWotWeEatDataService
    {
        Task<List<Vegetable>> GetVegetables();
        Task<List<MeatFish>> GetMeatFish();
        Task<MeatFish?> GetMeatFishByName(string name);
        Task<Vegetable?> GetVegetableByName(string name);
        Task<List<MealOption>> GetMealOptions();
        Task<Meal?> GetMeal(Guid id);
        Task<MealOption?> GetMealOption(Guid id);
        Task SaveVegetable(Vegetable vegetable);
        Task SaveMeatFish(MeatFish meatFish);
        Task SaveMealVariation(MealVariation mealVariation);
        Task SaveMealOption(MealOption mealOption);
        Task SaveMeal(Meal meal);
    }
}
