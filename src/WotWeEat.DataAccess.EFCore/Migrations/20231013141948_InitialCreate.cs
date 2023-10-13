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
                name: "MeatFish",
                columns: table => new
                {
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeatFish", x => x.ReferenceId);
                });

            migrationBuilder.CreateTable(
                name: "Vegetables",
                columns: table => new
                {
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vegetables", x => x.ReferenceId);
                });

            migrationBuilder.CreateTable(
                name: "MealOptions",
                columns: table => new
                {
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MealBase = table.Column<int>(type: "int", nullable: false),
                    SuitableForChildren = table.Column<bool>(type: "bit", nullable: false),
                    AmountOfWork = table.Column<int>(type: "int", nullable: false),
                    Healthy = table.Column<int>(type: "int", nullable: false),
                    MeatFishId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealOptions", x => x.ReferenceId);
                    table.ForeignKey(
                        name: "FK_MealOptions_MeatFish_MeatFishId",
                        column: x => x.MeatFishId,
                        principalTable: "MeatFish",
                        principalColumn: "ReferenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealOptionVegetable",
                columns: table => new
                {
                    VegetableReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealOptionReferenceIdId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealOptionVegetable", x => new { x.VegetableReferenceId, x.MealOptionReferenceIdId });
                    table.ForeignKey(
                        name: "FK_MealOptionVegetable_MealOptions_MealOptionReferenceIdId",
                        column: x => x.MealOptionReferenceIdId,
                        principalTable: "MealOptions",
                        principalColumn: "ReferenceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealOptionVegetable_Vegetables_VegetableReferenceId",
                        column: x => x.VegetableReferenceId,
                        principalTable: "Vegetables",
                        principalColumn: "ReferenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealVariations",
                columns: table => new
                {
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MealOptionReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealVariations", x => x.ReferenceId);
                    table.ForeignKey(
                        name: "FK_MealVariations_MealOptions_MealOptionId",
                        column: x => x.MealOptionId,
                        principalTable: "MealOptions",
                        principalColumn: "ReferenceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealVariations_MealOptions_MealOptionReferenceId",
                        column: x => x.MealOptionReferenceId,
                        principalTable: "MealOptions",
                        principalColumn: "ReferenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealOptions_MeatFishId",
                table: "MealOptions",
                column: "MeatFishId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealOptionVegetable_MealOptionReferenceIdId",
                table: "MealOptionVegetable",
                column: "MealOptionReferenceIdId");

            migrationBuilder.CreateIndex(
                name: "IX_MealVariations_MealOptionId",
                table: "MealVariations",
                column: "MealOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_MealVariations_MealOptionReferenceId",
                table: "MealVariations",
                column: "MealOptionReferenceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealOptionVegetable");

            migrationBuilder.DropTable(
                name: "MealVariations");

            migrationBuilder.DropTable(
                name: "Vegetables");

            migrationBuilder.DropTable(
                name: "MealOptions");

            migrationBuilder.DropTable(
                name: "MeatFish");
        }
    }
}
