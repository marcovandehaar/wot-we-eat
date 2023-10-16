using WotWeEat.Domain;

namespace WotWeEat.DataAccess.Interfaces;

public interface IWotWeEatRepository
{
    public Task SaveMealOption(MealOption mealOption);

    public Task<MealOption?> GetMealOption(Guid id);


    Task<List<Domain.Vegetable>> GetAllVegetables();
    Task<List<Domain.MeatFish>> GetAllMeatFish();
    Task SaveMeatFish(Domain.MeatFish meatFish);
    Task SaveVegetable(Domain.Vegetable vegetable);
    Task<Vegetable?> GetVegetableByName(string name);
    Task<MeatFish?> GetMeatFishByName(string name);
    Task<List<Domain.MealOption>> GetAllMealOptions();
}
