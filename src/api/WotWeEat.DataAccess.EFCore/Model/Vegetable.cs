using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WotWeEat.DataAccess.EFCore.Model;

public class Vegetable
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public IEnumerable<MealOption>? MealOptions { get; set; }
}