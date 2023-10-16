using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WotWeEat.DataAccess.EFCore.Model;
using WotWeEat.DataAccess.Interfaces;
using DomainModel = WotWeEat.Domain;

namespace WotWeEat.DataAccess.EFCore
{
    public class WotWeEatRepository : IWotWeEatRepository
    {
        private readonly WotWeEatDbContext _context;
        private readonly IMapper _mapper;

        public WotWeEatRepository(WotWeEatDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<DomainModel.MealOption?> GetMealOption(Guid mealOptionId)
        {
            // Use Entity Framework to retrieve the MealOption by MealOptionId
            var efMealOption =  await _context.MealOptions
                .Include(mo => mo.PossibleVariations) // Include related PossibleVariations
                .FirstOrDefaultAsync(mo => mo.MealOptionId == mealOptionId);

            return _mapper.Map<Domain.MealOption>(efMealOption);
        }

        public async Task SaveMealOption(DomainModel.MealOption mealOption)
        {
            if (mealOption.MealOptionId == Guid.Empty)
            {
                // It's a new MealOption, so add it
                var mealOptionEF = _mapper.Map<MealOption>(mealOption);
                _context.MealOptions.Add(mealOptionEF);
            }
            else
            {
                // It's an existing MealOption, so update it
                var existingMealOption =  await GetMealOption(mealOption.MealOptionId);

                if (existingMealOption != null)
                {
                    // Update properties of the existing MealOptionEF based on the input mealOption
                    _mapper.Map(mealOption, existingMealOption);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<DomainModel.Vegetable>> GetAllVegetables()
        {
            var efVegetables = await _context.Vegetables.ToListAsync();
            return _mapper.Map<List<DomainModel.Vegetable>>(efVegetables);
        }

        public async Task<List<DomainModel.MeatFish>> GetAllMeatFish()
        {
            var efMeatFish = await _context.MeatFishes.ToListAsync();
            return _mapper.Map<List<DomainModel.MeatFish>>(efMeatFish);
        }

        public async Task SaveMeatFish(DomainModel.MeatFish meatFish)
        {
            if (meatFish.MeatFishId == Guid.Empty)
            {
                // It's a new MeatFish, so add it
                var meatFishEF = _mapper.Map<MeatFish>(meatFish);
                _context.MeatFishes.Add(meatFishEF);
            }
            else
            {
                // It's an existing MeatFish, so update it
                var existingMeatFish = await _context.MeatFishes
                    .FirstOrDefaultAsync(mf => mf.MeatFishId == meatFish.MeatFishId);

                if (existingMeatFish != null)
                {
                    // Update properties of the existing MeatFishEF based on the input meatFish
                    _mapper.Map(meatFish, existingMeatFish);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task SaveVegetable(DomainModel.Vegetable vegetable)
        {
            if (vegetable.VegetableId == Guid.Empty)
            {
                // It's a new Vegetable, so add it
                var vegetableEF = _mapper.Map<Vegetable>(vegetable);
                _context.Vegetables.Add(vegetableEF);
            }
            else
            {
                // It's an existing Vegetable, so update it
                var existingVegetable = await _context.Vegetables
                    .FirstOrDefaultAsync(v => v.VegetableId == vegetable.VegetableId);

                if (existingVegetable != null)
                {
                    // Update properties of the existing VegetableEF based on the input vegetable
                    _mapper.Map(vegetable, existingVegetable);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<DomainModel.Vegetable?> GetVegetableByName(string name)
        {
            var efVegetable =  await _context.Vegetables.SingleOrDefaultAsync(v => v.Name == name);
            return efVegetable != null ? _mapper.Map<DomainModel.Vegetable>(efVegetable) : null;
        }

        public async Task<DomainModel.MeatFish?> GetMeatFishByName(string name)
        {
            var efMEatFish =  await _context.MeatFishes.SingleOrDefaultAsync(mf => mf.Name == name);
            return efMEatFish!=null ? _mapper.Map<DomainModel.MeatFish>(efMEatFish) : null;
        }



    }
}
