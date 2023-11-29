using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WotWeEat.DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MeatFish",
                columns: new[] { "MeatFishId", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("5ef7836e-12cf-480c-aaa5-3d77cb26a3cd"), "Fishsticks", 1 },
                    { new Guid("6549a061-b071-46ce-bdfa-136e6fa94726"), "Zalm", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MeatFish",
                keyColumn: "MeatFishId",
                keyValue: new Guid("5ef7836e-12cf-480c-aaa5-3d77cb26a3cd"));

            migrationBuilder.DeleteData(
                table: "MeatFish",
                keyColumn: "MeatFishId",
                keyValue: new Guid("6549a061-b071-46ce-bdfa-136e6fa94726"));
        }
    }
}
