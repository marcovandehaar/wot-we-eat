using System.Formats.Asn1;
using Microsoft.AspNetCore.Mvc;
using WotWeEat.DataAccess.EFCore;
using WotWeEat.DataAccess.Interfaces;
using WotWeEat.Domain;

namespace WotWeEat.Api.Controllers;

[ApiController]
[Route("api")]
public class WotWeEatQueryController : ControllerBase
{

    private readonly ILogger<WotWeEatQueryController> _logger;
    private readonly IWotWeEatDataService _dataService;

    public WotWeEatQueryController(ILogger<WotWeEatQueryController> logger, IWotWeEatDataService dataService)
    {
        _logger = logger;
        _dataService = dataService;
    }

    [HttpGet]
    [Route("vegetable")]
    public async Task<ActionResult<List<Vegetable>>> GetAllVegetables()
    {
        var vegetables = await _dataService.GetVegetables();
        if (vegetables.Count == 0)
        {
            return NotFound("No vegetables found.");
        }
        return vegetables;
    }

    [HttpGet]
    [Route("meat-fish")]
    public async Task<ActionResult<List<MeatFish>>> GetAllMeatFish()
    {
        var meatFish = await _dataService.GetMeatFish();
        if (meatFish.Count == 0)
        {
            return NotFound("No meatfish found.");
        }
        return meatFish;
    }

    [HttpGet]
    [Route("vegetable/{name}")]
    public async Task<ActionResult<Vegetable>> GetVegetableByName(string name)
    {
        var vegetable = await _dataService.GetVegetableByName(name);

        if (vegetable == null)
        {
            return NotFound("Vegetable not found.");
        }

        return vegetable;
    }

    [HttpGet]
    [Route("meatfish/{name}")]
    public async Task<ActionResult<MeatFish>> GetMeatFishByName(string name)
    {
        var meatFish = await _dataService.GetMeatFishByName(name);

        if (meatFish == null)
        {
            return NotFound("MeatFish not found.");
        }

        return meatFish;
    }

    [HttpGet]
    [Route("meal-option")]
    [ActionName(nameof(GetMealOption))]
    public async Task<ActionResult<List<MealOption>>> GetMealOptions(bool? active = null)
    {
        var mealOptions = await _dataService.GetMealOptions(active);

        if (mealOptions.Count == 0)
        {
            return NotFound("No MealOptions found.");
        }

        return mealOptions;
    }


    [HttpGet]
    [Route("meal-option/{id}")]
    [ActionName(nameof(GetMealOption))]
    public async Task<ActionResult<MealOption>> GetMealOption(Guid id)
    {
        var mealOption = await _dataService.GetMealOption(id);

        if (mealOption == null)
        {
            return NotFound("MealOption not found.");
        }

        return mealOption;
    }

    [HttpGet]
    [Route("meal/{id}")]
    public async Task<ActionResult<Meal>> GetMeal(Guid id)
    {
        var meal = await _dataService.GetMeal(id);

        if (meal == null)
        {
            return NotFound("Mealnot found.");
        }

        return meal;
    }
}
