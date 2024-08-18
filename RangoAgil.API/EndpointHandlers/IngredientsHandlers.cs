using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RangoAgil.API.DbContexts;
using RangoAgil.API.Entities;
using RangoAgil.API.Models;

namespace RangoAgil.API.EndpointHandlers;

public static class IngredientsHandlers
{
    public static async Task<Results<NotFound, Ok<IEnumerable<IngredientDTO>>>> GetIngredientsAsync(
    RangoDbContext rangoDbContext,
    IMapper mapper,
    int rangoId)
    {
        var result = await rangoDbContext.Rangos
                                   .FirstOrDefaultAsync(rango => rango.Id == rangoId);

        if (result == null) return TypedResults.NotFound();

        return TypedResults.Ok(mapper.Map<IEnumerable<IngredientDTO>>
        ((await rangoDbContext.Rangos
                                   .Include(rango => rango.Ingredients)
                                   .FirstOrDefaultAsync(rango => rango.Id == rangoId))?.Ingredients));
    }
}
