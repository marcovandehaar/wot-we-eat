using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WotWeEat.DataAccess.EFCore.Model;
using WotWeEat.Domain.Enum;

namespace WotWeEat.DataAccess.EFCore.Seed
{
    internal static class MeatFishsSeedExtensions
    {
        public static void SeedMeatFishes(this ModelBuilder builder)
        {
            var vegetables = new MeatFish[]
            {
                new()
                {
                    Id = new Guid("cb66e275-68fd-4b19-9f75-23a8789dcc19"),
                    Name = "Rundervink",
                    Type = MeatFishType.Meat
                },
                new()
                {
                    Id = new Guid("ba2de199-3aa8-4b88-b505-8d263f49e014"),
                    Name = "Gehakt",
                    Type = MeatFishType.Meat
                },
                new()
                {
                    Id = new Guid("32537ee6-b328-43c8-a1d2-346ffb7fd689"),
                    Name = "Speklap",
                    Type = MeatFishType.Meat
                },
                new()
                {
                    Id = new Guid("6549a061-b071-46ce-bdfa-136e6fa94726"),
                    Name = "Zalm",
                    Type = MeatFishType.Fish
                },
                new()
                {
                    Id = new Guid("5ef7836e-12cf-480c-aaa5-3d77cb26a3cd"),
                    Name = "Fishsticks",
                    Type = MeatFishType.Fish
                },


            };
            builder.Entity<MeatFish>().HasData(vegetables);
        }
    }
}