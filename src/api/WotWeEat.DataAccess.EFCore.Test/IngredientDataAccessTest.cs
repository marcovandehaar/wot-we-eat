using AutoMapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WotWeEat.DataAccess.EFCore.Model;
using Xunit;

namespace WotWeEat.DataAccess.EFCore.Test
{
    public class IngredientDataAccessTest 
    {
        private const string NewVegetableName = "New Vegetable";
        private const string NewMeatFishName = "New MeatFish";

        [Fact]
        public async Task TestVegetable()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<WotWeEatDbContext>().UseSqlite(connection).Options;

            using (var context = new WotWeEatDbContext(options))
            {
                context.Database.EnsureCreated();
            }

            var automapper = AutomapperTestHelper.GetAutomapper();
            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context,automapper);

                await repository.SaveVegetable(GetVegetable());

                context.SaveChanges();
            }

            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);

                var vegi = await repository.GetVegetableByName(NewVegetableName);

                Assert.Multiple(() =>
                {
                    Assert.NotNull(vegi);
                    Assert.Equal(1, context.Vegetable.Count());
                    Assert.NotEqual(Guid.NewGuid(), vegi.VegetableId);
                    Assert.Equal(NewVegetableName, vegi.Name);
                });
                
            }
        }

        [Fact]
        public async Task TestCreateMeatFish()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<WotWeEatDbContext>().UseSqlite(connection).Options;

            using (var context = new WotWeEatDbContext(options))
            {
                context.Database.EnsureCreated();
            }

            var automapper = AutomapperTestHelper.GetAutomapper();
            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);

                await repository.SaveMeatFish(GetMeatFish());

                context.SaveChanges();
            }

            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);

                var meatFish = await repository.GetMeatFishByName(NewMeatFishName);

                Assert.Multiple(() =>
                {
                    Assert.NotNull(meatFish);
                    Assert.Equal(1, context.MeatFish.Count());
                    Assert.NotEqual(Guid.NewGuid(), meatFish.MeatFishId);
                    Assert.Equal(NewMeatFishName, meatFish.Name);
                });

            }
        }

        [Fact]
        public async Task TestDuplicateMeatFish()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<WotWeEatDbContext>().UseSqlite(connection).Options;

            using (var context = new WotWeEatDbContext(options))
            {
                context.Database.EnsureCreated();
            }

            var automapper = AutomapperTestHelper.GetAutomapper();
            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);

                await repository.SaveMeatFish(GetMeatFish());

                context.SaveChanges();
            }

            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);
                // insert duplicate name
                 await Assert.ThrowsAsync<DbUpdateException>(async ()=> await repository.SaveMeatFish(GetMeatFish()));
            }
        }

        [Fact]
        public async Task TestDuplicateVegetable()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<WotWeEatDbContext>().UseSqlite(connection).Options;

            using (var context = new WotWeEatDbContext(options))
            {
                context.Database.EnsureCreated();
            }

            var automapper = AutomapperTestHelper.GetAutomapper();
            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);

                await repository.SaveVegetable(GetVegetable());

                context.SaveChanges();
            }

            using (var context = new WotWeEatDbContext(options))
            {
                var repository = new WotWeEatRepository(context, automapper);
                // insert duplicate name
                await Assert.ThrowsAsync<DbUpdateException>(async () => await repository.SaveVegetable(GetVegetable()));
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
    }
}
