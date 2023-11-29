using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WotWeEat.DataAccess.EFCore.Model;

namespace WotWeEat.DataAccess.EFCore.Seed
{
    internal static class VegetablesSeedExtensions
    {
        public static void SeedVegetables(this ModelBuilder builder)
        {
            var vegetables = new Vegetable[]
            {
                new()
                {
                    VegetableId = new Guid("1406ace7-58f7-4d31-af0d-3b95ff69b8bf"),
                    Name = "Sla"
                },
                new()
                {
                    VegetableId = new Guid("066434c6-3b89-48ae-831c-a046b25678bc"),
                    Name = "Rauwe groentes"
                },
                new()
                {
                    VegetableId = new Guid("e6a854d8-1655-43a7-bd8a-1d5cb9cfecd7"),
                    Name = "Boerenkool"
                },


            };
            builder.Entity<Vegetable>().HasData(vegetables);
        }
    }
}
