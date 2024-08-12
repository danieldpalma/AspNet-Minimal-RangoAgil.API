﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RangoAgil.API.DbContexts;

#nullable disable

namespace RangoAgil.API.Migrations
{
    [DbContext(typeof(RangoDbContext))]
    [Migration("20240812123637_CreatedDatabase")]
    partial class CreatedDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("IngredientRango", b =>
                {
                    b.Property<int>("IngredientsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RangosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("IngredientsId", "RangosId");

                    b.HasIndex("RangosId");

                    b.ToTable("IngredientRango");

                    b.HasData(
                        new
                        {
                            IngredientsId = 1,
                            RangosId = 1
                        },
                        new
                        {
                            IngredientsId = 2,
                            RangosId = 1
                        },
                        new
                        {
                            IngredientsId = 3,
                            RangosId = 1
                        },
                        new
                        {
                            IngredientsId = 4,
                            RangosId = 1
                        },
                        new
                        {
                            IngredientsId = 5,
                            RangosId = 1
                        },
                        new
                        {
                            IngredientsId = 6,
                            RangosId = 1
                        },
                        new
                        {
                            IngredientsId = 7,
                            RangosId = 1
                        },
                        new
                        {
                            IngredientsId = 8,
                            RangosId = 1
                        },
                        new
                        {
                            IngredientsId = 14,
                            RangosId = 1
                        },
                        new
                        {
                            IngredientsId = 9,
                            RangosId = 2
                        },
                        new
                        {
                            IngredientsId = 19,
                            RangosId = 2
                        },
                        new
                        {
                            IngredientsId = 11,
                            RangosId = 2
                        },
                        new
                        {
                            IngredientsId = 12,
                            RangosId = 2
                        },
                        new
                        {
                            IngredientsId = 13,
                            RangosId = 2
                        },
                        new
                        {
                            IngredientsId = 2,
                            RangosId = 2
                        },
                        new
                        {
                            IngredientsId = 21,
                            RangosId = 2
                        },
                        new
                        {
                            IngredientsId = 8,
                            RangosId = 2
                        },
                        new
                        {
                            IngredientsId = 1,
                            RangosId = 3
                        },
                        new
                        {
                            IngredientsId = 12,
                            RangosId = 3
                        },
                        new
                        {
                            IngredientsId = 17,
                            RangosId = 3
                        },
                        new
                        {
                            IngredientsId = 14,
                            RangosId = 3
                        },
                        new
                        {
                            IngredientsId = 2,
                            RangosId = 3
                        },
                        new
                        {
                            IngredientsId = 16,
                            RangosId = 3
                        },
                        new
                        {
                            IngredientsId = 23,
                            RangosId = 3
                        },
                        new
                        {
                            IngredientsId = 8,
                            RangosId = 3
                        },
                        new
                        {
                            IngredientsId = 1,
                            RangosId = 4
                        },
                        new
                        {
                            IngredientsId = 18,
                            RangosId = 4
                        },
                        new
                        {
                            IngredientsId = 16,
                            RangosId = 4
                        },
                        new
                        {
                            IngredientsId = 20,
                            RangosId = 4
                        },
                        new
                        {
                            IngredientsId = 22,
                            RangosId = 4
                        },
                        new
                        {
                            IngredientsId = 2,
                            RangosId = 4
                        },
                        new
                        {
                            IngredientsId = 21,
                            RangosId = 4
                        },
                        new
                        {
                            IngredientsId = 8,
                            RangosId = 4
                        },
                        new
                        {
                            IngredientsId = 24,
                            RangosId = 5
                        },
                        new
                        {
                            IngredientsId = 10,
                            RangosId = 5
                        },
                        new
                        {
                            IngredientsId = 23,
                            RangosId = 5
                        },
                        new
                        {
                            IngredientsId = 2,
                            RangosId = 5
                        },
                        new
                        {
                            IngredientsId = 12,
                            RangosId = 5
                        },
                        new
                        {
                            IngredientsId = 18,
                            RangosId = 5
                        },
                        new
                        {
                            IngredientsId = 14,
                            RangosId = 5
                        },
                        new
                        {
                            IngredientsId = 20,
                            RangosId = 5
                        },
                        new
                        {
                            IngredientsId = 13,
                            RangosId = 5
                        });
                });

            modelBuilder.Entity("RangoAgil.API.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Carne de Vaca"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cebola"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cerveja Escura"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Fatia de Pão Integral"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Mostarda"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Chicória"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Maionese"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Vários Temperos"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Mexilhões"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Aipo"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Batatas Fritas"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Tomate"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Extrato de Tomate"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Folha de Louro"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Cenoura"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Alho"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Vinho Tinto"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Leite de Coco"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Gengibre"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Pimenta Malagueta"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Tamarindo"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Peixe Firme"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Pasta de Gengibre e Alho"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Garam Masala"
                        });
                });

            modelBuilder.Entity("RangoAgil.API.Entities.Rango", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Rangos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ensopado Flamengo de Carne de Vaca com Chicória"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mexilhões com Batatas Fritas"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ragu alla Bolognese"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Rendang"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Masala de Peixe"
                        });
                });

            modelBuilder.Entity("IngredientRango", b =>
                {
                    b.HasOne("RangoAgil.API.Entities.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RangoAgil.API.Entities.Rango", null)
                        .WithMany()
                        .HasForeignKey("RangosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
