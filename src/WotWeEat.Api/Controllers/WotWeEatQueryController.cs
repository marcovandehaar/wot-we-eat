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
}
