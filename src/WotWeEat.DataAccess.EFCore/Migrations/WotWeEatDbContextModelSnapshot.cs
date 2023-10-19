﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WotWeEat.DataAccess.EFCore;

#nullable disable

namespace WotWeEat.DataAccess.EFCore.Migrations
{
    [DbContext(typeof(WotWeEatDbContext))]
    partial class WotWeEatDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MealOptionMeatFish", b =>
                {
                    b.Property<Guid>("MealOptionsMealOptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MeatFishesMeatFishId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MealOptionsMealOptionId", "MeatFishesMeatFishId");

                    b.HasIndex("MeatFishesMeatFishId");

                    b.ToTable("MealOptionMeatFish");
                });

            modelBuilder.Entity("MealOptionVegetable", b =>
                {
                    b.Property<Guid>("MealOptionsMealOptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VegetablesVegetableId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MealOptionsMealOptionId", "VegetablesVegetableId");

                    b.HasIndex("VegetablesVegetableId");

                    b.ToTable("MealOptionVegetable");
                });

            modelBuilder.Entity("WotWeEat.DataAccess.EFCore.Model.Meal", b =>
                {
                    b.Property<Guid>("MealId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MealOptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MealVariationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<bool>("WithChildren")
                        .HasColumnType("bit");

                    b.HasKey("MealId");

                    b.HasIndex("MealOptionId");

                    b.HasIndex("MealVariationId");

                    b.ToTable("Meal");
                });

            modelBuilder.Entity("WotWeEat.DataAccess.EFCore.Model.MealOption", b =>
                {
                    b.Property<Guid>("MealOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AmountOfWork")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Healthy")
                        .HasColumnType("int");

                    b.Property<int>("MealBase")
                        .HasColumnType("int");

                    b.Property<bool>("SuitableForChildren")
                        .HasColumnType("bit");

                    b.HasKey("MealOptionId");

                    b.ToTable("MealOption");
                });

            modelBuilder.Entity("WotWeEat.DataAccess.EFCore.Model.MealVariation", b =>
                {
                    b.Property<Guid>("MealVariationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MakeSuitableForKids")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MealOptionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MealVariationId");

                    b.HasIndex("MealOptionId");

                    b.ToTable("MealVariation");
                });

            modelBuilder.Entity("WotWeEat.DataAccess.EFCore.Model.MeatFish", b =>
                {
                    b.Property<Guid>("MeatFishId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("MeatFishId");

                    b.ToTable("MeatFish");
                });

            modelBuilder.Entity("WotWeEat.DataAccess.EFCore.Model.Vegetable", b =>
                {
                    b.Property<Guid>("VegetableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VegetableId");

                    b.ToTable("Vegetable");
                });

            modelBuilder.Entity("MealOptionMeatFish", b =>
                {
                    b.HasOne("WotWeEat.DataAccess.EFCore.Model.MealOption", null)
                        .WithMany()
                        .HasForeignKey("MealOptionsMealOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WotWeEat.DataAccess.EFCore.Model.MeatFish", null)
                        .WithMany()
                        .HasForeignKey("MeatFishesMeatFishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MealOptionVegetable", b =>
                {
                    b.HasOne("WotWeEat.DataAccess.EFCore.Model.MealOption", null)
                        .WithMany()
                        .HasForeignKey("MealOptionsMealOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WotWeEat.DataAccess.EFCore.Model.Vegetable", null)
                        .WithMany()
                        .HasForeignKey("VegetablesVegetableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WotWeEat.DataAccess.EFCore.Model.Meal", b =>
                {
                    b.HasOne("WotWeEat.DataAccess.EFCore.Model.MealOption", "MealOption")
                        .WithMany()
                        .HasForeignKey("MealOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WotWeEat.DataAccess.EFCore.Model.MealVariation", "Variation")
                        .WithMany()
                        .HasForeignKey("MealVariationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MealOption");

                    b.Navigation("Variation");
                });

            modelBuilder.Entity("WotWeEat.DataAccess.EFCore.Model.MealVariation", b =>
                {
                    b.HasOne("WotWeEat.DataAccess.EFCore.Model.MealOption", "MealOption")
                        .WithMany("PossibleVariations")
                        .HasForeignKey("MealOptionId");

                    b.Navigation("MealOption");
                });

            modelBuilder.Entity("WotWeEat.DataAccess.EFCore.Model.MealOption", b =>
                {
                    b.Navigation("PossibleVariations");
                });
#pragma warning restore 612, 618
        }
    }
}
