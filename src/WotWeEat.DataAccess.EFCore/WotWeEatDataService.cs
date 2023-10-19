using AutoMapper;
using WotWeEat.DataAccess.Interfaces;
using WotWeEat.Domain;

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
            return meatFish!=null ? _mapper.Map<MeatFish>(meatFish) : null;
        }

        public async Task<Vegetable?> GetVegetableByName(string name)
        {
            var vegetable = await _repository.GetVegetableByName(name);
            return vegetable!=null ? _mapper.Map<Vegetable>(vegetable) : null;
        }

        public async Task<List<MealOption>> GetMealOptions()
        {
            var mealOptions = await _repository.GetAllMealOptions();
            return _mapper.Map<List<MealOption>>(mealOptions);
        }

        public async Task<Meal?> GetMeal(Guid id)
        {
            var meal = await _repository.GetMeal(id);
            return meal !=null ? _mapper.Map<Meal>(meal): null;
        }

        public async Task<MealOption?> GetMealOption(Guid id)
        {
            var mealOption = await _repository.GetMealOption(id);
            return mealOption !=null ? _mapper.Map<MealOption>(mealOption): null;
        }

        public async Task SaveVegetable(Vegetable vegetable)
        {
            var mapped = _mapper.Map<Model.Vegetable>(vegetable);
            await _repository.SaveVegetable(mapped);
            vegetable.VegetableId = mapped.VegetableId;
        }

        public async Task SaveMeatFish(MeatFish meatFish)
        {
            var mapped = _mapper.Map<Model.MeatFish>(meatFish);
            await _repository.SaveMeatFish(mapped);
            meatFish.MeatFishId = mapped.MeatFishId;
        }

        public async Task SaveMealVariation(MealVariation mealVariation)
        {
            var mapped = _mapper.Map<Model.MealVariation>(mealVariation);
            await _repository.SaveMealVariation(mapped);
            mealVariation.MealVariationId = mapped.MealVariationId;
        }

        public async Task SaveMealOption(MealOption mealOption)
        {
            if (mealOption.MealOptionId != Guid.Empty)
            {
                var existing = _repository.GetMealOption(mealOption.MealOptionId);
                if (existing == null)
                {
                    throw new ArgumentException($"MealOption with Id {mealOption.MealOptionId} not found!");
                    
                }
                await _mapper.Map(mealOption, existing);
                await _repository.SaveMealOption(_mapper.Map<Model.MealOption>(existing));

            }
            else
            {
                var mapped = _mapper.Map<Model.MealOption>(mealOption);

                mealOption.MealOptionId = mapped.MealOptionId;
                await _repository.SaveMealOption(_mapper.Map<Model.MealOption>(mealOption));

            }

        }

        public async Task SaveMeal(Meal meal)
        {
            var mapped = _mapper.Map<Model.Meal>(meal);
            await _repository.SaveMeal(mapped);
            meal.MealId = mapped.MealId;
        }

    }
}
