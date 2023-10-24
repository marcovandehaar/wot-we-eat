using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WotWeEat.DataAccess.EFCore.Model;
using WotWeEat.Domain.Enum;
using Xunit;

namespace WotWeEat.DataAccess.EFCore.Test
{
    public class MealOptionDataAccessTest
    {
        private const string NewVegetableName = "New Vegetable";
        private const string NewMeatFishName = "New MeatFish";

        [Fact]
        public async Task TestCreateMealOption()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<WotWeEatDbContext>()
                .UseSqlite(connection)
                
                .Options;

            using (var context = new WotWeEatDbContext(options))
            {
                context.Database.EnsureCreated();
            }

            var automapper = AutomapperTestHelper.GetAutomapper();
            Guid newMealOptionId = Guid.Empty;;
            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);


                var newMealOption = GetNewMealOption();
                await repository.SaveMealOption(newMealOption);

                context.SaveChanges();
                newMealOptionId = newMealOption.MealOptionId;
            }

            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);

                var mealOptionFromDb= await repository.GetMealOption(newMealOptionId);

                Assert.Multiple(() =>
                {
                    Assert.NotNull(mealOptionFromDb);
                    Assert.Equal(1, context.MealOption.Count());
                    Assert.Equal(1, context.Vegetable.Count());
                    Assert.Equal(1, context.MeatFish.Count());
                    Assert.Equal(1, context.MealVariation.Count());

                });

            }
        }

        [Fact]
        public async Task TestCreateMealOptionWithExistingChildren()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<WotWeEatDbContext>().UseSqlite(connection).Options;

            using (var context = new WotWeEatDbContext(options))
            {
                context.Database.EnsureCreated();
            }

            var automapper = AutomapperTestHelper.GetAutomapper();
            Guid newMealOptionId1 = Guid.Empty; 
            Guid newVegetableId = Guid.Empty;
            Guid newMeatFishId = Guid.Empty;
            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);


                var newMealOption = GetNewMealOption();
                await repository.SaveMealOption(newMealOption);

                context.SaveChanges();
                newMealOptionId1 = newMealOption.MealOptionId;
                newVegetableId = newMealOption.Vegetables.First().VegetableId;
                newMeatFishId = newMealOption.MeatFishes.First().MeatFishId;
                
            }

            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);

                var newMealOption2 = GetNewMealOption();
                newMealOption2.Vegetables.First().VegetableId = newVegetableId;
                newMealOption2.MeatFishes.First().MeatFishId = newMeatFishId;
                await repository.SaveMealOption(newMealOption2);

                context.SaveChanges();

                Assert.Multiple(() =>
                {
                    Assert.Equal(2, context.MealOption.Count());
                    Assert.Equal(1, context.Vegetable.Count());
                    Assert.Equal(1, context.MeatFish.Count());
                    Assert.Equal(2, context.MealVariation.Count());

                });

            }
        }

        [Fact]
        public async Task TestUpdateMealOptionWithExistingChildren()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<WotWeEatDbContext>().UseSqlite(connection).Options;

            using (var context = new WotWeEatDbContext(options))
            {
                context.Database.EnsureCreated();
            }

            var automapper = AutomapperTestHelper.GetAutomapper();
            Guid newMealOptionId1 = Guid.Empty;
            Guid newVegetableId = Guid.Empty;
            Guid newMeatFishId = Guid.Empty;
            Guid newVariationId = Guid.Empty;
            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);


                var newMealOption = GetNewMealOption();
                await repository.SaveMealOption(newMealOption);

                context.SaveChanges();
                newMealOptionId1 = newMealOption.MealOptionId;
                newVegetableId = newMealOption.Vegetables.First().VegetableId;
                newMeatFishId = newMealOption.MeatFishes.First().MeatFishId;
                newVariationId = newMealOption.PossibleVariations.First().MealVariationId;

            }

            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);

                var existingMealOption = GetNewMealOption();
                existingMealOption.MealOptionId = newMealOptionId1;
                existingMealOption.Vegetables.First().VegetableId = newVegetableId;
                existingMealOption.MeatFishes.First().MeatFishId = newMeatFishId;
                existingMealOption.PossibleVariations.First().MealVariationId = newVariationId;
                await repository.SaveMealOption(existingMealOption);

                context.SaveChanges();

                Assert.Multiple(() =>
                {
                    Assert.Equal(1, context.MealOption.Count());
                    Assert.Equal(1, context.Vegetable.Count());
                    Assert.Equal(1, context.MeatFish.Count());
                    Assert.Equal(1, context.MealVariation.Count());

                });

            }
        }

        [Fact]
        public async Task TestUpdateMealOptionWithNewChildren()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<WotWeEatDbContext>().UseSqlite(connection).Options;

            using (var context = new WotWeEatDbContext(options))
            {
                context.Database.EnsureCreated();
            }

            var automapper = AutomapperTestHelper.GetAutomapper();
            Guid newMealOptionId1 = Guid.Empty;
            Guid newVegetableId = Guid.Empty;
            Guid newMeatFishId = Guid.Empty;
            Guid newVariationId = Guid.Empty;
            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);


                var newMealOption = GetNewMealOption();
                await repository.SaveMealOption(newMealOption);

                context.SaveChanges();
                newMealOptionId1 = newMealOption.MealOptionId;
                newVegetableId = newMealOption.Vegetables.First().VegetableId;
                newMeatFishId = newMealOption.MeatFishes.First().MeatFishId;
                newVariationId = newMealOption.PossibleVariations.First().MealVariationId;
            }

            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);

                var existingMealOption = GetNewMealOption(newVegetableId, newMeatFishId, newVariationId);
                existingMealOption.MealOptionId = newMealOptionId1;
                var newVegetable = GetVegetable();
                newVegetable.Name = "Paprika";
                var newMeatFish = GetMeatFish();
                newMeatFish.Name = "Ham";
                var newMealVariation = new MealVariation()
                {
                    Description = "Met extra kaas!"
                };
                existingMealOption.Vegetables.Add(newVegetable);
                existingMealOption.MeatFishes.Add(newMeatFish);
                existingMealOption.PossibleVariations.Add(newMealVariation);
                await repository.SaveMealOption(existingMealOption);

                context.SaveChanges();


                Assert.Multiple(() =>
                {
                    Assert.Equal(1, context.MealOption.Count());
                    Assert.Equal(2, context.Vegetable.Count());
                    Assert.Equal(2, context.MeatFish.Count());
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

        public MealOption GetNewMealOption(Guid? vegetableId = null, Guid? meatFishId = null, Guid? newVariationId = null)
        {
            var mealOption = new MealOption()
            {
                Description = "Meatlovers Pizza",
                AmountOfWork = AmountOfWork.LotOfWork,
                Healthy = Healthy.Unhealthy,
                MealBase = MealBase.Dough,
                MeatFishes = new List<MeatFish>()
                {
                    new MeatFish()
                    {
                        Name = "Salami",
                        Type = MeatFishType.Meat,
                        MeatFishId = meatFishId ?? Guid.Empty
                    }
                },
                PossibleVariations = new List<MealVariation>()
                {
                    new MealVariation()
                    {
                        MealVariationId = newVariationId ?? Guid.Empty,
                        Description = "Uber meat",
                        MakeSuitableForKids = false
                    }
                },
                Vegetables = new List<Vegetable>()
                {
                    new Vegetable()
                    {
                        Name = "Tomato",
                        VegetableId = vegetableId ?? Guid.Empty
                    }
                },
                SuitableForChildren = true
            };
            return mealOption;
        }
    }
}
