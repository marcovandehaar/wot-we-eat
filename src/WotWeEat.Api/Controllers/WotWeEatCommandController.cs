using Microsoft.AspNetCore.Mvc;
using WotWeEat.DataAccess.EFCore.Model;
using WotWeEat.DataAccess.Interfaces;
using WotWeEat.Domain;
using WotWeEat.Domain.Enum;
using MealOption = WotWeEat.Domain.MealOption;
using MeatFish = WotWeEat.Domain.MeatFish;
using Vegetable = WotWeEat.Domain.Vegetable;

namespace WotWeEat.Api.Controllers
{
    [ApiController]
    [Route("api/command")]
    public class WotWeEatCommandController : ControllerBase
    {
        private readonly ILogger<WotWeEatQueryController> _logger;
        private readonly IWotWeEatRepository _repository;

        public WotWeEatCommandController(ILogger<WotWeEatQueryController> logger, IWotWeEatRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("vegetables")]
        public async Task<IActionResult> CreateVegetable([FromBody] Vegetable vegetable)
        {
            try
            {
                // Validate the vegetableDto and perform any necessary input validation

                if (ModelState.IsValid)
                {
                    // Check if a vegetable with the same name already exists
                    var existingVegetable = await _repository.GetVegetableByName(vegetable.Name);
                    if (existingVegetable != null)
                    {
                        return Conflict("A vegetable with this name already exists.");
                    }

                    // Save the new vegetable
                    await _repository.SaveVegetable(vegetable);

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
                // Validate the meatFishDto and perform any necessary input validation

                if (!Enum.IsDefined(typeof(MeatFishType), meatFish.Type))
                {
                    ModelState.AddModelError(nameof(meatFish.Type), "Invalid MeatFishType.");
                    return BadRequest(ModelState);
                }
                if (ModelState.IsValid)
                {

                    // Check if a meatfish with the same name already exists
                    var existingMeatFish = await _repository.GetMeatFishByName(meatFish.Name);
                    if (existingMeatFish != null)
                    {
                        return Conflict("A meatfish with this name already exists.");
                    }

                    // Save the new meatfish
                    await _repository.SaveMeatFish(meatFish);

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
                // Validate the meatFishDto and perform any necessary input validation

                if (!Enum.IsDefined(typeof(MealBase), mealOption.MealBase.GetValueOrDefault()))
                {
                    ModelState.AddModelError(nameof(mealOption.MealBase), "Invalid MeatFishType.");
                    return BadRequest(ModelState);
                }
                if (!Enum.IsDefined(typeof(Healthy), mealOption.Healthy.GetValueOrDefault()))
                {
                    ModelState.AddModelError(nameof(mealOption.Healthy), "Invalid Healthy.");
                    return BadRequest(ModelState);
                }
                if (!Enum.IsDefined(typeof(AmountOfWork), mealOption.AmountOfWork.GetValueOrDefault()))
                {
                    ModelState.AddModelError(nameof(mealOption.AmountOfWork), "Invalid AmountOfWork.");
                    return BadRequest(ModelState);
                }
                if (ModelState.IsValid)
                {

                    // Save the new meatfish
                    await _repository.SaveMealOption(mealOption);

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

    }

}
