using Microsoft.AspNetCore.Mvc;

using WotWeEat.DataAccess.Interfaces;
using WotWeEat.Domain;


namespace WotWeEat.Api.Controllers
{
    [ApiController]
    [Route("api/command")]
    public class WotWeEatCommandController : ControllerBase
    {
        private readonly ILogger<WotWeEatQueryController> _logger;
        private readonly IWotWeEatDataService _dataService;

        public WotWeEatCommandController(ILogger<WotWeEatQueryController> logger, IWotWeEatDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [HttpPost("vegetables")]
        public async Task<IActionResult> CreateVegetable([FromBody] Vegetable vegetable)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Check if a vegetable with the same name already exists
                    var existingVegetable = await _dataService.GetVegetableByName(vegetable.Name);
                    if (existingVegetable != null)
                    {
                        return Conflict("A vegetable with this name already exists.");
                    }

                    // Save the new vegetable
                    await _dataService.SaveVegetable(vegetable);

                    // Return a success response or the newly created vegetable
                    return CreatedAtAction("GetVegetableByName", "WotWeEatQuery", new { name = vegetable.Name }, vegetable);

                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                // Handle and log exceptions
                return StatusCode(500, "An error occurred while creating the vegetable.");
            }

            

        }

        [HttpPost("meatfish")]
        public async Task<IActionResult> CreateMeatFish([FromBody] MeatFish meatFish)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    // Check if a meatfish with the same name already exists
                    var existingMeatFish = await _dataService.GetMeatFishByName(meatFish.Name);
                    if (existingMeatFish != null)
                    {
                        return Conflict("A meatfish with this name already exists.");
                    }

                    // Save the new meatfish
                    await _dataService.SaveMeatFish(meatFish);

                    // Return a success response or the newly created meatfish
                    return CreatedAtAction("GetMeatFishByName", "WotWeEatQuery", new { name = meatFish.Name }, meatFish);
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                // Handle and log exceptions
                return StatusCode(500, "An error occurred while creating the meatfish.");
            }
        }

        [HttpPost("mealoption")]
        public async Task<IActionResult> CreateMealOption([FromBody] MealOption mealOption)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    // Save the new meatfish
                    await _dataService.SaveMealOption(mealOption);

                    // Return a success response or the newly created meatfish
                    return CreatedAtAction(nameof(WotWeEatQueryController.GetMealOption), "WotWeEatQuery", new { id = mealOption.MealOptionId }, mealOption);
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                // Handle and log exceptions
                return StatusCode(500, "An error occurred while creating the meatfish.");
            }
        }

        [HttpPost("meal")]
        public async Task<IActionResult> CreateMeal([FromBody] Meal meal)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    // Save the new meatfish
                    await _dataService.SaveMeal(meal);

                    // Return a success response or the newly created meatfish
                    return CreatedAtAction(nameof(WotWeEatQueryController.GetMeal), "WotWeEatQuery", new { id = meal.MealId }, meal);
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                // Handle and log exceptions
                return StatusCode(500, "An error occurred while creating the meal.");
            }
        }

    }

}
