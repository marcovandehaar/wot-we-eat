using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WotWeEat.DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MealOption",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MealBase = table.Column<int>(type: "int", nullable: false),
                    SuitableForChildren = table.Column<bool>(type: "bit", nullable: false),
                    AmountOfWork = table.Column<int>(type: "int", nullable: true),
                    Healthy = table.Column<int>(type: "int", nullable: false),
                    InSeasons = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealOption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vegetable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vegetable", x => x.Id);
                    table.UniqueConstraint("AK_Vegetable_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "MealVariation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MealOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MakeSuitableForKids = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealVariation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealVariation_MealOption_MealOptionId",
                        column: x => x.MealOptionId,
                        principalTable: "MealOption",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MealOptionVegetable",
                columns: table => new
                {
                    MealOptionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VegetablesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealOptionVegetable", x => new { x.MealOptionsId, x.VegetablesId });
                    table.ForeignKey(
                        name: "FK_MealOptionVegetable_MealOption_MealOptionsId",
                        column: x => x.MealOptionsId,
                        principalTable: "MealOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealOptionVegetable_Vegetable_VegetablesId",
                        column: x => x.VegetablesId,
                        principalTable: "Vegetable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    WithChildren = table.Column<bool>(type: "bit", nullable: false),
                    MealOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealVariationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meal_MealOption_MealOptionId",
                        column: x => x.MealOptionId,
                        principalTable: "MealOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meal_MealVariation_MealVariationId",
                        column: x => x.MealVariationId,
                        principalTable: "MealVariation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MeatFish",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeatFish", x => x.Id);
                    table.UniqueConstraint("AK_MeatFish_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_MeatFish_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MealOptionMeatFish",
                columns: table => new
                {
                    MealOptionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PossibleMeatFishesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealOptionMeatFish", x => new { x.MealOptionsId, x.PossibleMeatFishesId });
                    table.ForeignKey(
                        name: "FK_MealOptionMeatFish_MealOption_MealOptionsId",
                        column: x => x.MealOptionsId,
                        principalTable: "MealOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealOptionMeatFish_MeatFish_PossibleMeatFishesId",
                        column: x => x.PossibleMeatFishesId,
                        principalTable: "MeatFish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MeatFish",
                columns: new[] { "Id", "MealId", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("32537ee6-b328-43c8-a1d2-346ffb7fd689"), null, "Speklap", 0 },
                    { new Guid("5ef7836e-12cf-480c-aaa5-3d77cb26a3cd"), null, "Fishsticks", 1 },
                    { new Guid("6549a061-b071-46ce-bdfa-136e6fa94726"), null, "Zalm", 1 },
                    { new Guid("ba2de199-3aa8-4b88-b505-8d263f49e014"), null, "Gehakt", 0 },
                    { new Guid("cb66e275-68fd-4b19-9f75-23a8789dcc19"), null, "Rundervink", 0 }
                });

            migrationBuilder.InsertData(
                table: "Vegetable",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("066434c6-3b89-48ae-831c-a046b25678bc"), "Rauwe groentes" },
                    { new Guid("1406ace7-58f7-4d31-af0d-3b95ff69b8bf"), "Sla" },
                    { new Guid("e6a854d8-1655-43a7-bd8a-1d5cb9cfecd7"), "Boerenkool" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meal_MealOptionId",
                table: "Meal",
                column: "MealOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_MealVariationId",
                table: "Meal",
                column: "MealVariationId");

            migrationBuilder.CreateIndex(
                name: "IX_MealOptionMeatFish_PossibleMeatFishesId",
                table: "MealOptionMeatFish",
                column: "PossibleMeatFishesId");

            migrationBuilder.CreateIndex(
                name: "IX_MealOptionVegetable_VegetablesId",
                table: "MealOptionVegetable",
                column: "VegetablesId");

            migrationBuilder.CreateIndex(
                name: "IX_MealVariation_MealOptionId",
                table: "MealVariation",
                column: "MealOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_MeatFish_MealId",
                table: "MeatFish",
                column: "MealId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealOptionMeatFish");

            migrationBuilder.DropTable(
                name: "MealOptionVegetable");

            migrationBuilder.DropTable(
                name: "MeatFish");

            migrationBuilder.DropTable(
                name: "Vegetable");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropTable(
                name: "MealVariation");

            migrationBuilder.DropTable(
                name: "MealOption");
        }
    }
}
