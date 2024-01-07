using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WotWeEat.DataAccess.EFCore.Model;


namespace WotWeEat.DataAccess.EFCore
{
    public class WotWeEatRepository : IWotWeEatRepository
    {
        private readonly WotWeEatDbContext _context;
        private readonly IMapper _mapper;


        public WotWeEatRepository(WotWeEatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MealOption?> GetMealOption(Guid mealOptionId)
        {
            // Use Entity Framework to retrieve the MealOption by MealOptionId
            var efMealOption = await _context.MealOption
                .Include(mo => mo.PossibleVariations) // Include related PossibleVariations
                .Include(mo => mo.PossibleMeatFishes) // Include related PossibleVariations
                .Include(mo => mo.Vegetables) // Include related PossibleVariations
                .FirstOrDefaultAsync(mo => mo.Id == mealOptionId);
            return efMealOption;
        }

        public async Task<Meal?> GetMeal(Guid meal)
        {
            // Use Entity Framework to retrieve the MealOption by MealOptionId
            var efMeal = _context.Meal
                .Include(m => m.MeatFishes)
                .Include(m => m.MealOption)         // Load the MealOption
                    .ThenInclude(mo => mo.PossibleMeatFishes)  // Load the Vegetables of the MealOption
                .Include(m => m.MealOption)         // Load the MealOption    
                    .ThenInclude(mo => mo.Vegetables)  // Load the PossibleMeatFishes of the MealOption
                .Include(m => m.MealOption)         // Load the MealOption    
                    .ThenInclude(mo => mo.PossibleVariations)  // Load the PossibleMeatFishes of the MealOption
                .Include(m => m.Variation)            // Load the Variation of the Meal
                .FirstOrDefault(m => m.Id == meal);
            return efMeal;
        }

        public async Task<List<MealOption>> GetAllMealOptions(bool? isActive = null)
        {
            var query = _context.MealOption.AsQueryable();

            if (isActive.HasValue)
            {
                query = query.Where(mo => mo.Active == isActive.Value);
            }

            return await query
                .Include(mo => mo.PossibleVariations)
                .Include(mo => mo.PossibleMeatFishes)
                .Include(mo => mo.Vegetables)
                .ToListAsync();
        }



        public async Task<MealOption> SaveMealOption(MealOption mealOption)
        {
            await SaveMealOptionWithoutSave(mealOption);
            await _context.SaveChangesAsync();
            return mealOption;
        }

        private async Task SaveMealOptionWithoutSave(MealOption mealOption)
        {
            foreach (var vegetable in mealOption.Vegetables)
            {
                if (vegetable.Id == Guid.Empty)
                {
                    await SaveVegetableWithoutSave(vegetable);
                }
                else
                {
                    
                    var loopVegetable = vegetable;
                    var existingEntity = _context.Set<Vegetable>().Local.FirstOrDefault(e => e.Name == vegetable.Name);
                    if (existingEntity != null)
                    {
                        loopVegetable = existingEntity;
                    }
                    _context.SetEntityState(loopVegetable, EntityState.Unchanged);
                }
            }

            foreach (var meatFish in mealOption.PossibleMeatFishes)
            {
                if (meatFish.Id == Guid.Empty)
                {
                    await SaveMeatFishWithoutSave(meatFish);
                }
                else
                {
                    var loopMeatFish = meatFish;
                    var existingEntity = _context.Set<MeatFish>().Local.FirstOrDefault(e => e.Name == meatFish.Name);
                    if (existingEntity != null)
                    {
                        loopMeatFish = existingEntity;
                    }
                    _context.SetEntityState(loopMeatFish, EntityState.Unchanged);
                }
            }

            if (mealOption.Id == Guid.Empty)
            {
                _context.MealOption.Add(mealOption);
            }
            else
            {
                // It's an existing MealOption, so update it
                var existingMealOption = await GetMealOption(mealOption.Id);

                if (existingMealOption != null)
                {
                    // Update properties of the existing MealOptionEF based on the input mealOption
                    _mapper.Map(mealOption, existingMealOption);

                    foreach (var existingVariation in existingMealOption.PossibleVariations.ToList())
                    {
                        if (!mealOption.PossibleVariations.Any(mv => mv.Id == existingVariation.Id))
                        {
                            // Remove the MealVariation from existingMealOption
                            _context.Remove(existingVariation);
                        }
                    }

                    foreach (var newVariation in mealOption.PossibleVariations)
                    {
                        if (!existingMealOption.PossibleVariations.Any(v =>
                                v.Id == newVariation.Id))
                        {
                            existingMealOption.PossibleVariations.Add(newVariation);
                        }
                    }
                }
            }
        }

        public async Task<Meal> SaveMeal(Meal meal)
        {


            if (meal.MealOption != null && meal.MealOption.Id == Guid.Empty)
            {
                await SaveMealOption(meal.MealOption);
            }
            else
            {
                await SaveMealOptionWithoutSave(meal.MealOption);
            }

            if (meal.Variation != null && meal.Variation.Id == Guid.Empty)
            {
                await SaveMealVariation(meal.Variation);
            }
            if (meal.Id == Guid.Empty)
            {
                
                // It's a new Meal, so add it
                meal.MealOptionId = meal.MealOption.Id;
                meal.MealOption = null;
                _context.Add(meal);
                Console.WriteLine($"state: {_context.Entry(meal).State} ");
            }
            else
            {
                // It's an existing Meal, so update it
                var existingMeal = await GetMeal(meal.Id);

                if (existingMeal != null)
                {
                    _mapper.Map(meal, existingMeal);
                }
                else
                {
                    throw new ArgumentException($"Meal with id {meal.Id} not found!");
                }
            }
            Console.WriteLine($"state: {_context.Entry(meal).State} ");

            var mealVariant = meal.Variation;
            if (mealVariant != null && mealVariant.Id == Guid.Empty)
            {
                
                await SaveMealVariation(mealVariant);
            }
            Console.WriteLine($"state: {_context.Entry(meal).State} ");

            if (meal.Variation != null && meal.Variation.Id != Guid.Empty)
            {
                _context.SetEntityState(meal.Variation, EntityState.Unchanged);
            }
            Console.WriteLine($"state: {_context.Entry(meal).State} ");

            await _context.SaveChangesAsync();
            return meal;
        }

        public async Task<List<Vegetable>> GetAllVegetables()
        {
            return await _context.Vegetable.ToListAsync();
        }

        public async Task<List<MeatFish>> GetAllMeatFish()
        {
            return await _context.MeatFish.ToListAsync();
        }

        public async Task<MeatFish> SaveMeatFish(MeatFish meatFish)
        {
            await SaveMeatFishWithoutSave(meatFish);

            await _context.SaveChangesAsync();
            return meatFish;
        }

        private async Task SaveMeatFishWithoutSave(MeatFish meatFish)
        {
            if (meatFish.Id == Guid.Empty)
            {
                // It's a new MeatFish, so add it
                _context.MeatFish.Add(meatFish);
            }
            else
            {
                // It's an existing MeatFish, so update it
                var existingMeatFish = await _context.MeatFish
                    .FirstOrDefaultAsync(mf => mf.Id == meatFish.Id);

                if (existingMeatFish != null)
                {
                    // Update properties of the existing MeatFishEF based on the input meatFish
                    _mapper.Map(meatFish, existingMeatFish);
                }
            }
        }

        public async Task<MealVariation> SaveMealVariation(MealVariation mealVariation)
        {
            await SaveMealVariationWithoutSave(mealVariation);

            await _context.SaveChangesAsync();
            return mealVariation;
        }

        private async Task SaveMealVariationWithoutSave(MealVariation mealVariation)
        {
            if (mealVariation?.MealOption == null)
            {
                throw new ArgumentException("MealVariation should always have a linked option!");
            }

            if (mealVariation.Id == Guid.Empty)
            {
                // It's a new MealVariation, so link it and add it
                if (mealVariation.MealOption.Id != Guid.Empty)
                {
                    mealVariation.MealOptionId = mealVariation.MealOption.Id;
                    mealVariation.MealOption = null;
                }
                
                _context.MealVariation.Add(mealVariation);
            }
            else
            {
                // It's an existing MealVariation, so update it
                var existingMealVariation = await _context.MealVariation
                    .FirstOrDefaultAsync(mf => mf.Id == mealVariation.Id);

                if (existingMealVariation != null)
                {
                    // Update properties of the existing MealVariation based on the input meatFish
                    _mapper.Map(mealVariation, existingMealVariation);
                }
            }
        }

        public async Task<Vegetable> SaveVegetable(Vegetable vegetable)
        {
            await SaveVegetableWithoutSave(vegetable);

            await _context.SaveChangesAsync();
            return vegetable;
        }

        private async Task SaveVegetableWithoutSave(Vegetable vegetable)
        {
            if (vegetable.Id == Guid.Empty)
            {
                // It's a new Vegetable, so add it
                vegetable.Id = Guid.NewGuid();
                _context.Vegetable.Add(vegetable);
            }
            else
            {
                // It's an existing Vegetable, so update it
                var existingVegetable = await _context.Vegetable
                    .FirstOrDefaultAsync(v => v.Id == vegetable.Id);

                if (existingVegetable != null)
                {
                    // Update properties of the existing VegetableEF based on the input vegetable
                    _mapper.Map(vegetable, existingVegetable);
                }
            }
        }


        public async Task<Vegetable?> GetVegetableByName(string name)
        {
            return  await _context.Vegetable.SingleOrDefaultAsync(v => v.Name == name);
        }

        public async Task<MeatFish?> GetMeatFishByName(string name)
        {
            return  await _context.MeatFish.SingleOrDefaultAsync(mf => mf.Name == name);
        }


    }
}
