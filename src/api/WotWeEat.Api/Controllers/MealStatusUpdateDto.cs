using WotWeEat.Domain.Enum;

namespace WotWeEat.Api.Controllers;

public class MealStatusUpdateDto
{
    public SuggestionStatus NewStatus { get; set; }
}