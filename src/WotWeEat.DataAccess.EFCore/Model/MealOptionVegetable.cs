

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WotWeEat.DataAccess.EFCore.Model
{
    public class MealOptionVegetable
    {
        public Guid MealOptionId { get; set; }
        public MealOption? MealOption { get; set; }
        public Guid VegetableId { get; set; }
        public Vegetable? Vegetable { get; set; }
    }
}

