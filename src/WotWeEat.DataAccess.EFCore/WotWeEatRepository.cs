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
    internal class WotWeEatRepository : IWotWeEatRepository
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

    }
}
