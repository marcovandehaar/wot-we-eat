using AutoMapper;
using WotWeEat.DataAccess.Interfaces;
using WotWeEat.Domain;
using WotWeEat.Domain.Enum;


namespace WotWeEat.DataAccess.EFCore
{
    public class WotWeEatDataService : IWotWeEatDataService
    {
        private readonly IMapper _mapper;
        private readonly IWotWeEatRepository _repository;

        public WotWeEatDataService(IMapper mapper, IWotWeEatRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<Vegetable>> GetVegetables()
        {
            var vegetables = await _repository.GetAllVegetables();
            return _mapper.Map<List<Vegetable>>(vegetables);
        }

        public async Task<List<MeatFish>> GetMeatFish()
        {
            var vegetables = await _repository.GetAllMeatFish();
            return _mapper.Map<List<MeatFish>>(vegetables);
        }

        public async Task<MeatFish?> GetMeatFishByName(string name)
        {
            var meatFish = await _repository.GetMeatFishByName(name);
            return meatFish != null ? _mapper.Map<MeatFish>(meatFish) : null;
        }

        public async Task<Vegetable?> GetVegetableByName(string name)
        {
            var vegetable = await _repository.GetVegetableByName(name);
            return vegetable != null ? _mapper.Map<Vegetable>(vegetable) : null;
        }

        public async Task<List<MealOption>> GetMealOptions(bool? isActive = null)
        {
            var mealOptions = await _repository.GetAllMealOptions(isActive);
            return _mapper.Map<List<MealOption>>(mealOptions);
        }

        public async Task<List<Meal>> GetMeals()
        {
            var meals = await _repository.GetAllMeals();
            return _mapper.Map<List<Meal>>(meals);
        }

        public async Task<Meal?> GetMeal(Guid id)
        {
            var meal = await _repository.GetMeal(id);
            return meal != null ? _mapper.Map<Meal>(meal) : null;
        }

        public async Task<MealOption?> GetMealOption(Guid id)
        {
            var mealOption = await _repository.GetMealOption(id);
            return mealOption != null ? _mapper.Map<MealOption>(mealOption) : null;
        }

        public async Task<Vegetable> SaveVegetable(Vegetable vegetable)
        {
            var mapped = _mapper.Map<Model.Vegetable>(vegetable);
            var created = await _repository.SaveVegetable(mapped);
            return _mapper.Map<Vegetable>(created);
        }

        public async Task<MeatFish> SaveMeatFish(MeatFish meatFish)
        {
            var mapped = _mapper.Map<Model.MeatFish>(meatFish);
            var created = await _repository.SaveMeatFish(mapped);
            return _mapper.Map<MeatFish>(created);
        }

        public async Task<MealVariation> SaveMealVariation(MealVariation mealVariation)
        {
            var mapped = _mapper.Map<Model.MealVariation>(mealVariation);
            var created = await _repository.SaveMealVariation(mapped);
            return _mapper.Map<MealVariation>(created); ;
        }

        public async Task<MealOption> SaveMealOption(MealOption mealOption)
        {
            var created = await _repository.SaveMealOption(_mapper.Map<Model.MealOption>(mealOption));
            return _mapper.Map<MealOption>(created);
        }

        public async Task<Meal> SaveMeal(Meal meal)
        {
            var mapped = _mapper.Map<Model.Meal>(meal);
            var created = await _repository.SaveMeal(mapped);
            return _mapper.Map<Meal>(created);
        }

        public async Task UpdateMealSuggestionStatus(Guid mealId, SuggestionStatus newStatus)
        {
            await _repository.UpdateMealSuggestionStatus(mealId, newStatus);
        }

    }
}
