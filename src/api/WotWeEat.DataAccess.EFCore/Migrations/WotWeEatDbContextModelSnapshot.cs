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
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MealOptionMeatFish", b =>
                {
                    b.Property<Guid>("MealOptionsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PossibleMeatFishesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MealOptionsId", "PossibleMeatFishesId");

                    b.HasIndex("PossibleMeatFishesId");

                    b.ToTable("MealOptionMeatFish");
                });

            modelBuilder.Entity("MealOptionVegetable", b =>
                {
                    b.Property<Guid>("MealOptionsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VegetablesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MealOptionsId", "VegetablesId");

                    b.HasIndex("VegetablesId");

                    b.ToTable("MealOptionVegetable");
                });

            modelBuilder.Entity("WotWeEat.DataAccess.EFCore.Model.Meal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MealOptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MealVariationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("SuggestionStatus")
                        .HasColumnType("int");

                    b.Property<bool>("WithChildren")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MealOptionId");

                    b.HasIndex("MealVariationId");

                    b.ToTable("Meal");
                });

            modelBuilder.Entity("WotWeEat.DataAccess.EFCore.Model.MealOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("AmountOfWork")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Healthy")
                        .HasColumnType("int");

                    b.Property<int?>("InSeasons")
                        .HasColumnType("int");

                    b.Property<int>("MealBase")
                        .HasColumnType("int");

                    b.Property<bool>("SuitableForChildren")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("MealOption");
                });

            modelBuilder.Entity("WotWeEat.DataAccess.EFCore.Model.MealVariation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MakeSuitableForKids")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MealOptionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MealOptionId");

                    b.ToTable("MealVariation");
                });

            modelBuilder.Entity("WotWeEat.DataAccess.EFCore.Model.MeatFish", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MealId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("MealId");

                    b.ToTable("MeatFish");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cb66e275-68fd-4b19-9f75-23a8789dcc19"),
                            Name = "Rundervink",
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("ba2de199-3aa8-4b88-b505-8d263f49e014"),
                            Name = "Gehakt",
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("32537ee6-b328-43c8-a1d2-346ffb7fd689"),
                            Name = "Speklap",
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("6549a061-b071-46ce-bdfa-136e6fa94726"),
                            Name = "Zalm",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("5ef7836e-12cf-480c-aaa5-3d77cb26a3cd"),
                            Name = "Fishsticks",
                            Type = 1
                        });
                });

            modelBuilder.Entity("WotWeEat.DataAccess.EFCore.Model.Vegetable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Vegetable");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1406ace7-58f7-4d31-af0d-3b95ff69b8bf"),
                            Name = "Sla"
                        },
                        new
                        {
                            Id = new Guid("066434c6-3b89-48ae-831c-a046b25678bc"),
                            Name = "Rauwe groentes"
                        },
                        new
                        {
                            Id = new Guid("e6a854d8-1655-43a7-bd8a-1d5cb9cfecd7"),
                            Name = "Boerenkool"
                        });
                });

            modelBuilder.Entity("MealOptionMeatFish", b =>
                {
                    b.HasOne("WotWeEat.DataAccess.EFCore.Model.MealOption", null)
                        .WithMany()
                        .HasForeignKey("MealOptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WotWeEat.DataAccess.EFCore.Model.MeatFish", null)
                        .WithMany()
                        .HasForeignKey("PossibleMeatFishesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MealOptionVegetable", b =>
                {
                    b.HasOne("WotWeEat.DataAccess.EFCore.Model.MealOption", null)
                        .WithMany()
                        .HasForeignKey("MealOptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WotWeEat.DataAccess.EFCore.Model.Vegetable", null)
                        .WithMany()
                        .HasForeignKey("VegetablesId")
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
                        .HasForeignKey("MealVariationId");

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

            modelBuilder.Entity("WotWeEat.DataAccess.EFCore.Model.MeatFish", b =>
                {
                    b.HasOne("WotWeEat.DataAccess.EFCore.Model.Meal", null)
                        .WithMany("MeatFishes")
                        .HasForeignKey("MealId");
                });

            modelBuilder.Entity("WotWeEat.DataAccess.EFCore.Model.Meal", b =>
                {
                    b.Navigation("MeatFishes");
                });

            modelBuilder.Entity("WotWeEat.DataAccess.EFCore.Model.MealOption", b =>
                {
                    b.Navigation("PossibleVariations");
                });
#pragma warning restore 612, 618
        }
    }
}
