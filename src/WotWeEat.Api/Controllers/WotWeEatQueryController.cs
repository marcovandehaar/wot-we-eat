using Microsoft.AspNetCore.Mvc;
using WotWeEat.DataAccess.Interfaces;
using WotWeEat.Domain;

namespace WotWeEat.Api.Controllers;

[ApiController]
[Route("api/query")]
public class WotWeEatQueryController : ControllerBase
{

    private readonly ILogger<WotWeEatQueryController> _logger;
    private readonly IWotWeEatRepository _repository;

    public WotWeEatQueryController(ILogger<WotWeEatQueryController> logger, IWotWeEatRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    [Route("vegetables/all")]
    public async Task<ActionResult<List<Vegetable>>> GetAllVegetables()
    {
        var vegetables = await _repository.GetAllVegetables();
        if (vegetables.Count == 0)
        {
            return NotFound("No vegetables found.");
        }
        return vegetables;
    }

    [HttpGet]
    [Route("meatfish/all")]
    public async Task<ActionResult<List<MeatFish>>> GetAllMeatFish()
    {
        var meatFish = await _repository.GetAllMeatFish();
        if (meatFish.Count == 0)
        {
            return NotFound("No meatfish found.");
        }
        return meatFish;
    }

    [HttpGet]
    [Route("vegetables/{name}")]
    public async Task<ActionResult<Vegetable>> GetVegetableByName(string name)
    {
        var vegetable = await _repository.GetVegetableByName(name);

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
        var meatFish = await _repository.GetMeatFishByName(name);

        if (meatFish == null)
        {
            return NotFound("MeatFish not found.");
        }

        return meatFish;
    }

    [HttpGet]
    [Route("mealOption/{id}")]
    [ActionName(nameof(GetMealOption))]
    public async Task<ActionResult<MealOption>> GetMealOption(Guid id)
    {
        var mealOption = await _repository.GetMealOption(id);

        if (mealOption == null)
        {
            return NotFound("MealOption not found.");
        }

        return mealOption;
    }
}
