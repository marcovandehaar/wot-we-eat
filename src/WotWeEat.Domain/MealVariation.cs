namespace WotWeEat.Domain;

public class MealVariation
{
    public Guid ReferenceId { get; set; }
    public string Description { get; set; }
    public MealOption MealOption { get; set; }
    public Guid? MealOptionId { get; set; }
}