using WotWeEat.Domain;

namespace WotWeEat.DataAccess.Interfaces;

public interface IWotWeEatRepository
{
    public Task SaveMealOption(MealOption mealOption);

    public Task<MealOption?> GetMealOption(Guid id);



}
