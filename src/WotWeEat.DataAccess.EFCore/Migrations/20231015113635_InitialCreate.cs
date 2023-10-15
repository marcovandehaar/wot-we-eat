using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WotWeEat.DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MealOptions",
                columns: table => new
                {
                    MealOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MealBase = table.Column<int>(type: "int", nullable: false),
                    SuitableForChildren = table.Column<bool>(type: "bit", nullable: false),
                    AmountOfWork = table.Column<int>(type: "int", nullable: false),
                    Healthy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealOptions", x => x.MealOptionId);
                });

            migrationBuilder.CreateTable(
                name: "MeatFishes",
                columns: table => new
                {
                    MeatFishId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeatFishes", x => x.MeatFishId);
                });

            migrationBuilder.CreateTable(
                name: "Vegetables",
                columns: table => new
                {
                    VegetableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vegetables", x => x.VegetableId);
                });

            migrationBuilder.CreateTable(
                name: "MealVariation",
                columns: table => new
                {
                    MealVariationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MealOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MakeSuitableForKids = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealVariation", x => x.MealVariationId);
                    table.ForeignKey(
                        name: "FK_MealVariation_MealOptions_MealOptionId",
                        column: x => x.MealOptionId,
                        principalTable: "MealOptions",
                        principalColumn: "MealOptionId");
                });

            migrationBuilder.CreateTable(
                name: "MealOptionMeatFish",
                columns: table => new
                {
                    MealOptionsMealOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MeatFishesMeatFishId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealOptionMeatFish", x => new { x.MealOptionsMealOptionId, x.MeatFishesMeatFishId });
                    table.ForeignKey(
                        name: "FK_MealOptionMeatFish_MealOptions_MealOptionsMealOptionId",
                        column: x => x.MealOptionsMealOptionId,
                        principalTable: "MealOptions",
                        principalColumn: "MealOptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealOptionMeatFish_MeatFishes_MeatFishesMeatFishId",
                        column: x => x.MeatFishesMeatFishId,
                        principalTable: "MeatFishes",
                        principalColumn: "MeatFishId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealOptionVegetable",
                columns: table => new
                {
                    MealOptionsMealOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VegetablesVegetableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealOptionVegetable", x => new { x.MealOptionsMealOptionId, x.VegetablesVegetableId });
                    table.ForeignKey(
                        name: "FK_MealOptionVegetable_MealOptions_MealOptionsMealOptionId",
                        column: x => x.MealOptionsMealOptionId,
                        principalTable: "MealOptions",
                        principalColumn: "MealOptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealOptionVegetable_Vegetables_VegetablesVegetableId",
                        column: x => x.VegetablesVegetableId,
                        principalTable: "Vegetables",
                        principalColumn: "VegetableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    WithChildren = table.Column<bool>(type: "bit", nullable: false),
                    MealOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealVariationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.MealId);
                    table.ForeignKey(
                        name: "FK_Meal_MealOptions_MealOptionId",
                        column: x => x.MealOptionId,
                        principalTable: "MealOptions",
                        principalColumn: "MealOptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meal_MealVariation_MealVariationId",
                        column: x => x.MealVariationId,
                        principalTable: "MealVariation",
                        principalColumn: "MealVariationId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_MealOptionMeatFish_MeatFishesMeatFishId",
                table: "MealOptionMeatFish",
                column: "MeatFishesMeatFishId");

            migrationBuilder.CreateIndex(
                name: "IX_MealOptionVegetable_VegetablesVegetableId",
                table: "MealOptionVegetable",
                column: "VegetablesVegetableId");

            migrationBuilder.CreateIndex(
                name: "IX_MealVariation_MealOptionId",
                table: "MealVariation",
                column: "MealOptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropTable(
                name: "MealOptionMeatFish");

            migrationBuilder.DropTable(
                name: "MealOptionVegetable");

            migrationBuilder.DropTable(
                name: "MealVariation");

            migrationBuilder.DropTable(
                name: "MeatFishes");

            migrationBuilder.DropTable(
                name: "Vegetables");

            migrationBuilder.DropTable(
                name: "MealOptions");
        }
    }
}
