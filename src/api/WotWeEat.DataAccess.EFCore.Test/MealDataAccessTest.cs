using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WotWeEat.DataAccess.EFCore.Model;
using WotWeEat.Domain.Enum;
using Xunit;

namespace WotWeEat.DataAccess.EFCore.Test
{
    public class MealDataAccessTest
    {
        private const string NewVegetableName = "New Vegetable";
        private const string NewMeatFishName = "New MeatFish";


        [Fact]
        public async Task TestCreateMeal()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<WotWeEatDbContext>()
                .UseSqlite(connection)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .Options;

            using (var context = new WotWeEatDbContext(options))
            {
                context.Database.EnsureCreated();
            }
            var seededVegetables = 0;
            var seededMeatFishes = 0;
            var automapper = AutomapperTestHelper.GetAutomapper();
            Guid mealMealId = Guid.Empty; ;
            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);

                var mf = await repository.GetAllMeatFish();
                var v = await repository.GetAllVegetables();
                seededMeatFishes = mf.Count;
                seededVegetables = v.Count;


                var newMeal = GetNewMeal();
                await repository.SaveMeal(newMeal);

                context.SaveChanges();
                mealMealId = newMeal.Id;
            }

            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);

                var mealFromDb = await repository.GetMeal(mealMealId);

                Assert.Multiple(() =>
                {
                    Assert.NotNull(mealFromDb);
                    Assert.NotNull(mealFromDb.Variation);
                    Assert.Equal(1, context.Meal.Count());
                    Assert.Equal(1, context.MealOption.Count());
                    Assert.Equal(seededVegetables+1, context.Vegetable.Count());
                    Assert.Equal(seededMeatFishes+1, context.MeatFish.Count());
                    Assert.Equal(1, context.MealVariation.Count());

                });

            }
        }

        [Fact]
        public async Task TestCreateMealWithExistingMealOption()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<WotWeEatDbContext>()
                .UseSqlite(connection)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .Options;

            using (var context = new WotWeEatDbContext(options))
            {
                context.Database.EnsureCreated();
            }

            var seededVegetables = 0;
            var seededMeatFishes = 0;
            var automapper = AutomapperTestHelper.GetAutomapper();
            Guid newMealId = Guid.Empty; ;
            Guid mealOptionId = Guid.Empty; ;
            Guid vegetableId = Guid.Empty ;
            Guid meatFishId = Guid.Empty ;
            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);

                var mf = await repository.GetAllMeatFish();
                var v = await repository.GetAllVegetables();
                seededMeatFishes = mf.Count;
                seededVegetables = v.Count;

                var mealOption = GetMealOption();
                await repository.SaveMealOption(mealOption);
                mealOptionId = mealOption.Id;
                vegetableId = mealOption.Vegetables.First().Id;
                meatFishId = mealOption.PossibleMeatFishes.First().Id;


            }

            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);

                var mealOption = GetMealOption(mealOptionId);
                mealOption.PossibleMeatFishes.First().Id = meatFishId;
                mealOption.Vegetables.First().Id= vegetableId;
                var newMeal = GetNewMeal(null, mealOptionId);
                newMeal.MealOption = mealOption;

                await repository.SaveMeal(newMeal);

                context.SaveChanges();
                newMealId = newMeal.Id;
            }
            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);

                var mealFromDb = await repository.GetMeal(newMealId);
                Assert.Multiple(() =>
                {
                    Assert.NotNull(mealFromDb);
                    Assert.NotNull(mealFromDb.MealOption);
                    Assert.Equal(1, context.Meal.Count());
                    Assert.Equal(1, context.MealOption.Count());
                    Assert.Equal(seededVegetables+1, context.Vegetable.Count());
                    Assert.Equal(seededMeatFishes+1, context.MeatFish.Count());
                    Assert.Equal(2, context.MealVariation.Count());

                });

            }
        }

        private Vegetable GetVegetable()
        {
            return new Vegetable()
            {
                Name = NewVegetableName
            };
        }

        private MeatFish GetMeatFish()
        {
            return new MeatFish()
            {
                Name = NewMeatFishName
            };
        }

        public Meal GetNewMeal(Guid? mealId = null, Guid? mealOptionId = null)
        {
            var mealOption = GetMealOption(mealOptionId);
            var meal = new Meal()
            {
                MealOption = mealOption,
                MealOptionId = mealOptionId ?? Guid.Empty,
                MealVariationId = mealOption.PossibleVariations.First().Id,
                Date = new DateTime(2023, 5, 5),
                Rating = MealRating.Good,
                Id = mealId ?? Guid.Empty,
                Variation = mealOption.PossibleVariations.First(),
                WithChildren = true
            };
            return meal;
        }

        public MealOption GetMealOption(Guid? mealOptionId = null, Guid? meatFishId= null, Guid? vegetableId = null )
        {
            var variation = GetMealVariation(mealOptionId);
            var mealOption = new MealOption()
            {
                Description = "Meatlovers Pizza",
                AmountOfWork = 10,
                Healthy = Healthy.Unhealthy,
                MealBase = MealBase.Dough,
                Id = mealOptionId?? Guid.Empty,
                PossibleMeatFishes = new List<MeatFish>()
                {
                    new MeatFish()
                    {
                        Name = "Salami",
                        Type = MeatFishType.Meat,
                        Id = meatFishId?? Guid.Empty
                    }
                },
                PossibleVariations = new List<MealVariation>()
                {
                    variation
                },
                Vegetables = new List<Vegetable>()
                {
                    new Vegetable()
                    {
                        Name = "Tomato",
                        Id = vegetableId?? Guid.Empty
                    }
                },
                SuitableForChildren = true
            };
            variation.MealOption = mealOption;
            return mealOption;
        }

        private static MealVariation GetMealVariation(Guid? mealOptionid = null)
        {
            return new MealVariation()
            {
                Id = Guid.Empty,
                Description = "Uber meat",
                MakeSuitableForKids = false,
                MealOptionId = mealOptionid
            };
        }
    }
}
