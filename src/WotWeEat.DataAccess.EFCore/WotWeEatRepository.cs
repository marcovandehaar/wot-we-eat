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
                .Include(mo => mo.MeatFishes) // Include related PossibleVariations
                .Include(mo => mo.Vegetables) // Include related PossibleVariations
                .FirstOrDefaultAsync(mo => mo.MealOptionId == mealOptionId);
            return efMealOption;
        }

        public async Task<Meal?> GetMeal(Guid meal)
        {
            // Use Entity Framework to retrieve the MealOption by MealOptionId
            var efMeal = await _context.Meal
                .Include(mo => mo.MealOption) // Include related PossibleVariations
                .Include(mo => mo.Variation) // Include related PossibleVariations
                .FirstOrDefaultAsync(mo => mo.MealOptionId == meal);
            return efMeal;
        }

        public async Task<List<MealOption>> GetAllMealOptions()
        {
            return await _context.MealOption
                .Include(mo => mo.PossibleVariations)
                .Include(mo => mo.MeatFishes)
                .Include(mo => mo.Vegetables)
                .ToListAsync();
        }


        public async Task SaveMealOption(MealOption mealOption)
        {
            foreach (var vegetable in mealOption.Vegetables)
            {
                if (vegetable.VegetableId == Guid.Empty)
                {
                    await SaveVegetableWithoutSave(vegetable);
                }
                else
                {
                    _context.SetEntityState(vegetable, EntityState.Unchanged);
                }
            }

            foreach (var meatFish in mealOption.MeatFishes)
            {
                if (meatFish.MeatFishId == Guid.Empty)
                {
                    await SaveMeatFishWithoutSave(meatFish);
                }
                else
                {
                    _context.SetEntityState(meatFish, EntityState.Unchanged);
                }
            }

            if (mealOption.MealOptionId == Guid.Empty)
            {
                //hier gaat het mis.... ik moet die properties nullen, maar ik moet ze ook nog netjes opslaan. dus dat onderste stuk moet naar boven...
                _context.MealOption.Add(mealOption);
            }
            else
            {
                // It's an existing MealOption, so update it
                var existingMealOption =  await GetMealOption(mealOption.MealOptionId);

                if (existingMealOption != null)
                {
                    // Update properties of the existing MealOptionEF based on the input mealOption
                    _mapper.Map(mealOption, existingMealOption);

                    foreach (var existingVariation in existingMealOption.PossibleVariations.ToList())
                    {
                        if (!mealOption.PossibleVariations.Any(mv => mv.MealVariationId == existingVariation.MealVariationId))
                        {
                            // Remove the MealVariation from existingMealOption
                            _context.Remove(existingVariation);
                        }
                    }

                }

            }
            foreach (var possibleVariation in mealOption.PossibleVariations)
            {
                if (possibleVariation.MealVariationId == Guid.Empty)
                {
                    possibleVariation.MealOptionId = mealOption.MealOptionId;
                    possibleVariation.MealOption = mealOption;
                    await SaveMealVariationWithoutSave(possibleVariation);
                }
                else
                {
                    _context.SetEntityState(possibleVariation, EntityState.Unchanged);
                }
            }



            await _context.SaveChangesAsync();
        }

        public async Task SaveMeal(Meal meal)
        {
            if (meal.MealId == Guid.Empty)
            {
                // It's a new MealOption, so add it
                _context.Meal.Add(meal);
            }
            else
            {
                // It's an existing MealOption, so update it
                var existingMeal = await GetMeal(meal.MealId);

                if (existingMeal != null)
                {
                    // Update properties of the existing MealOptionEF based on the input mealOption
                    _mapper.Map(meal, existingMeal);
                }
                else
                {
                    throw new ArgumentException($"Meal with id {meal.MealId} not found!");
                }
            }
            //check children, if new children present, save them.
            var mealOption = meal.MealOption;
            if (mealOption != null && mealOption.MealOptionId == Guid.Empty)
            {
                await SaveMealOption(mealOption);
            }
            var mealVariant = meal.Variation;
            if (mealVariant != null && mealVariant.MealVariationId == Guid.Empty)
            {
                
                await SaveMealVariation(mealVariant);
            }

            //prevent EF from trying to persist the children. This has been done, and foreign key is set.
            meal.MealOption = null;
            meal.Variation = null;

            await _context.SaveChangesAsync();
        }

        public async Task<List<Vegetable>> GetAllVegetables()
        {
            return await _context.Vegetable.ToListAsync();
        }

        public async Task<List<MeatFish>> GetAllMeatFish()
        {
            return await _context.MeatFish.ToListAsync();
        }

        public async Task SaveMeatFish(MeatFish meatFish)
        {
            await SaveMeatFishWithoutSave(meatFish);

            await _context.SaveChangesAsync();
        }

        private async Task SaveMeatFishWithoutSave(MeatFish meatFish)
        {
            if (meatFish.MeatFishId == Guid.Empty)
            {
                // It's a new MeatFish, so add it
                _context.MeatFish.Add(meatFish);
            }
            else
            {
                // It's an existing MeatFish, so update it
                var existingMeatFish = await _context.MeatFish
                    .FirstOrDefaultAsync(mf => mf.MeatFishId == meatFish.MeatFishId);

                if (existingMeatFish != null)
                {
                    // Update properties of the existing MeatFishEF based on the input meatFish
                    _mapper.Map(meatFish, existingMeatFish);
                }
            }
        }

        public async Task SaveMealVariation(MealVariation mealVariation)
        {
            await SaveMealVariationWithoutSave(mealVariation);

            await _context.SaveChangesAsync();
        }

        private async Task SaveMealVariationWithoutSave(MealVariation mealVariation)
        {
            if (mealVariation?.MealOption == null)
            {
                throw new ArgumentException("MealVariation should always have a linked option!");
            }

            if (mealVariation.MealVariationId == Guid.Empty)
            {
                // It's a new MealVariation, so link it and add it
                mealVariation.MealOptionId = mealVariation.MealOption.MealOptionId;
                _context.MealVariation.Add(mealVariation);
            }
            else
            {
                // It's an existing MealVariation, so update it
                var existingMealVariation = await _context.MealVariation
                    .FirstOrDefaultAsync(mf => mf.MealVariationId == mealVariation.MealVariationId);

                if (existingMealVariation != null)
                {
                    // Update properties of the existing MealVariation based on the input meatFish
                    _mapper.Map(mealVariation, existingMealVariation);
                }
            }
        }

        public async Task SaveVegetable(Vegetable vegetable)
        {
            await SaveVegetableWithoutSave(vegetable);

            await _context.SaveChangesAsync();
        }

        private async Task SaveVegetableWithoutSave(Vegetable vegetable)
        {
            if (vegetable.VegetableId == Guid.Empty)
            {
                // It's a new Vegetable, so add it
                vegetable.VegetableId = Guid.NewGuid();
                _context.Vegetable.Add(vegetable);
            }
            else
            {
                // It's an existing Vegetable, so update it
                var existingVegetable = await _context.Vegetable
                    .FirstOrDefaultAsync(v => v.VegetableId == vegetable.VegetableId);

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
