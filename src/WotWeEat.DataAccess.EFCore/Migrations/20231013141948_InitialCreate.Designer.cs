﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WotWeEat.DataAccess.EFCore;

#nullable disable

namespace WotWeEat.DataAccess.EFCore.Migrations
{
    [DbContext(typeof(WotWeEatDbContext))]
    [Migration("20231013141948_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MealOptionVegetable", b =>
                {
                    b.Property<Guid>("VegetableReferenceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MealOptionReferenceIdId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VegetableReferenceId", "MealOptionReferenceIdId");

                    b.HasIndex("MealOptionReferenceIdId");

                    b.ToTable("MealOptionVegetable");
                });

            modelBuilder.Entity("WotWeEat.Domain.MealOption", b =>
                {
                    b.Property<Guid>("ReferenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AmountOfWork")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Healthy")
                        .HasColumnType("int");

                    b.Property<int>("MealBase")
                        .HasColumnType("int");

                    b.Property<Guid>("MeatFishId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("SuitableForChildren")
                        .HasColumnType("bit");

                    b.HasKey("ReferenceId");

                    b.HasIndex("MeatFishId")
                        .IsUnique();

                    b.ToTable("MealOptions", (string)null);
                });

            modelBuilder.Entity("WotWeEat.Domain.MealVariation", b =>
                {
                    b.Property<Guid>("ReferenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MealOptionId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MealOptionReferenceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReferenceId");

                    b.HasIndex("MealOptionId");

                    b.HasIndex("MealOptionReferenceId");

                    b.ToTable("MealVariations", (string)null);
                });

            modelBuilder.Entity("WotWeEat.Domain.MeatFish", b =>
                {
                    b.Property<Guid>("ReferenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ReferenceId");

                    b.ToTable("MeatFish", (string)null);
                });

            modelBuilder.Entity("WotWeEat.Domain.Vegetable", b =>
                {
                    b.Property<Guid>("ReferenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReferenceId");

                    b.ToTable("Vegetables", (string)null);
                });

            modelBuilder.Entity("MealOptionVegetable", b =>
                {
                    b.HasOne("WotWeEat.Domain.MealOption", null)
                        .WithMany()
                        .HasForeignKey("MealOptionReferenceIdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WotWeEat.Domain.Vegetable", null)
                        .WithMany()
                        .HasForeignKey("VegetableReferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WotWeEat.Domain.MealOption", b =>
                {
                    b.HasOne("WotWeEat.Domain.MeatFish", "MeatFish")
                        .WithOne()
                        .HasForeignKey("WotWeEat.Domain.MealOption", "MeatFishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeatFish");
                });

            modelBuilder.Entity("WotWeEat.Domain.MealVariation", b =>
                {
                    b.HasOne("WotWeEat.Domain.MealOption", null)
                        .WithMany("PossibleVariations")
                        .HasForeignKey("MealOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WotWeEat.Domain.MealOption", "MealOption")
                        .WithMany()
                        .HasForeignKey("MealOptionReferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MealOption");
                });

            modelBuilder.Entity("WotWeEat.Domain.MealOption", b =>
                {
                    b.Navigation("PossibleVariations");
                });
#pragma warning restore 612, 618
        }
    }
}
