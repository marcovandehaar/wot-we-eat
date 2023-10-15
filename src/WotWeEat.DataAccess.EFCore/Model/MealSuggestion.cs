using WotWeEat.Domain.Enum;

namespace WotWeEat.DataAccess.EFCore.Model;

public class MealSuggestion
{

    public Guid MealSuggestionId { get; set; }
    public MealOption? Option { get; set; }
    public Meal? ResultedInMeal { get; set; }
    public DateTime DateSuggested { get; set; }
    public bool Choice { get; set; }
    public ReasonNotChosen? ReasonNotChosen { get; set; }
}