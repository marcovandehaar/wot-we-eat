using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WotWeEat.DataAccess.EFCore.Model
{
    public class MealOptionMeatFish
    {
        public Guid MealOptionId { get; set; }
        public MealOption MealOption { get; set; }
        public Guid MeatFishId { get; set; }
        public MeatFish MeatFish { get; set; }
    }
}
