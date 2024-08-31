using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RangoAgil.API.Entities;

namespace RangoAgil.API.DbContexts;

public class RangoDbContext(DbContextOptions<RangoDbContext> options) :IdentityDbContext(options)
{
    public DbSet<Rango> Rangos { get; set; } = null!;
    public DbSet<Ingredient> Ingredients { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<Ingredient>().HasData(
        new { Id = 1, Name = "Carne de Vaca" },
        new { Id = 2, Name = "Cebola" },
        new { Id = 3, Name = "Cerveja Escura" },
        new { Id = 4, Name = "Fatia de Pão Integral" },
        new { Id = 5, Name = "Mostarda" },
        new { Id = 6, Name = "Chicória" },
        new { Id = 7, Name = "Maionese" },
        new { Id = 8, Name = "Vários Temperos" },
        new { Id = 9, Name = "Mexilhões" },
        new { Id = 10, Name = "Aipo" },
        new { Id = 11, Name = "Batatas Fritas" },
        new { Id = 12, Name = "Tomate" },
        new { Id = 13, Name = "Extrato de Tomate" },
        new { Id = 14, Name = "Folha de Louro" },
        new { Id = 15, Name = "Cenoura" },
        new { Id = 16, Name = "Alho" },
        new { Id = 17, Name = "Vinho Tinto" },
        new { Id = 18, Name = "Leite de Coco" },
        new { Id = 19, Name = "Gengibre" },
        new { Id = 20, Name = "Pimenta Malagueta" },
        new { Id = 21, Name = "Tamarindo" },
        new { Id = 22, Name = "Peixe Firme" },
        new { Id = 23, Name = "Pasta de Gengibre e Alho" },
        new { Id = 24, Name = "Garam Masala" });

        _ = modelBuilder.Entity<Rango>().HasData(
            new { Id = 1, Name = "Ensopado Flamengo de Carne de Vaca com Chicória" },
            new { Id = 2, Name = "Mexilhões com Batatas Fritas" },
            new { Id = 3, Name = "Ragu alla Bolognese" },
            new { Id = 4, Name = "Rendang" },
            new { Id = 5, Name = "Masala de Peixe" });

        _ = modelBuilder
            .Entity<Rango>()
            .HasMany(d => d.Ingredients)
            .WithMany(i => i.Rangos)
            .UsingEntity(e => e.HasData(
                new { RangosId = 1, IngredientsId = 1 },
                new { RangosId = 1, IngredientsId = 2 },
                new { RangosId = 1, IngredientsId = 3 },
                new { RangosId = 1, IngredientsId = 4 },
                new { RangosId = 1, IngredientsId = 5 },
                new { RangosId = 1, IngredientsId = 6 },
                new { RangosId = 1, IngredientsId = 7 },
                new { RangosId = 1, IngredientsId = 8 },
                new { RangosId = 1, IngredientsId = 14 },
                new { RangosId = 2, IngredientsId = 9 },
                new { RangosId = 2, IngredientsId = 19 },
                new { RangosId = 2, IngredientsId = 11 },
                new { RangosId = 2, IngredientsId = 12 },
                new { RangosId = 2, IngredientsId = 13 },
                new { RangosId = 2, IngredientsId = 2 },
                new { RangosId = 2, IngredientsId = 21 },
                new { RangosId = 2, IngredientsId = 8 },
                new { RangosId = 3, IngredientsId = 1 },
                new { RangosId = 3, IngredientsId = 12 },
                new { RangosId = 3, IngredientsId = 17 },
                new { RangosId = 3, IngredientsId = 14 },
                new { RangosId = 3, IngredientsId = 2 },
                new { RangosId = 3, IngredientsId = 16 },
                new { RangosId = 3, IngredientsId = 23 },
                new { RangosId = 3, IngredientsId = 8 },
                new { RangosId = 4, IngredientsId = 1 },
                new { RangosId = 4, IngredientsId = 18 },
                new { RangosId = 4, IngredientsId = 16 },
                new { RangosId = 4, IngredientsId = 20 },
                new { RangosId = 4, IngredientsId = 22 },
                new { RangosId = 4, IngredientsId = 2 },
                new { RangosId = 4, IngredientsId = 21 },
                new { RangosId = 4, IngredientsId = 8 },
                new { RangosId = 5, IngredientsId = 24 },
                new { RangosId = 5, IngredientsId = 10 },
                new { RangosId = 5, IngredientsId = 23 },
                new { RangosId = 5, IngredientsId = 2 },
                new { RangosId = 5, IngredientsId = 12 },
                new { RangosId = 5, IngredientsId = 18 },
                new { RangosId = 5, IngredientsId = 14 },
                new { RangosId = 5, IngredientsId = 20 },
                new { RangosId = 5, IngredientsId = 13 }
            ));

        base.OnModelCreating(modelBuilder);
    }
}
