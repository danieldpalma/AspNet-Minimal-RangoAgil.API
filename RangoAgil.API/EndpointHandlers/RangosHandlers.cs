using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RangoAgil.API.DbContexts;
using RangoAgil.API.Entities;
using RangoAgil.API.Models;

namespace RangoAgil.API.EndpointHandlers;

public static class RangosHandlers
{
    public static async Task<Results<NoContent, Ok<IEnumerable<RangoDTO>>>> GetRangosAsync(
        RangoDbContext rangoDbContext,
        IMapper mapper,
        ILogger<RangoDTO> logger,
        [FromQuery(Name = "name")] string? name)
    {
        var result = await rangoDbContext.Rangos
                                    .Where(x => name == null || x.Name.ToLower().Contains(name.ToLower()))
                                    .ToListAsync();

        if (result.Count <= 0 || result == null)
        {
            logger.LogInformation($"Rango not found. Parameter: {name}");
            return TypedResults.NoContent();
        }
        else
        {
            logger.LogInformation("Getting the found Rango");
            return TypedResults.Ok(mapper.Map<IEnumerable<RangoDTO>>(result));
        }

    }

    public static async Task<Results<NotFound, Ok<RangoDTO>>> GetRangoById(
        RangoDbContext rangoDbContext,
        IMapper mapper,
        int rangoId)
    {
        var result = await rangoDbContext.Rangos.FirstOrDefaultAsync(x => x.Id == rangoId);

        if (result == null) return TypedResults.NotFound();

        return TypedResults.Ok(mapper.Map<RangoDTO>(result));
    }

    public static async Task<CreatedAtRoute<RangoDTO>> CreateRangoAsync(
        RangoDbContext rangoDbContext,
        IMapper mapper,
        [FromBody] RangoForCreateDTO rangoForCreateDTO)
    {
        var result = mapper.Map<Rango>(rangoForCreateDTO);
        rangoDbContext.Add(result);
        await rangoDbContext.SaveChangesAsync();

        var rangoToReturn = mapper.Map<RangoDTO>(result);

        return TypedResults.CreatedAtRoute(rangoToReturn, "GetRangos", new { rangoId = rangoToReturn.Id });

    }

    public static async Task<Results<NotFound, Ok>> UpdateRangoAsync(
        RangoDbContext rangoDbContext,
        IMapper mapper,
        int rangoId,
        [FromBody] RangoForUpdateDTO rangoForUpdateDTO)
    {
        var result = await rangoDbContext.Rangos.FirstOrDefaultAsync(x => x.Id == rangoId);

        if (result == null) return TypedResults.NotFound();

        mapper.Map(rangoForUpdateDTO, result);

        await rangoDbContext.SaveChangesAsync();

        return TypedResults.Ok();
    }

    public static async Task<Results<NotFound, NoContent>> DeleteRangoAsync(
        RangoDbContext rangoDbContext,
        int rangoId)
    {
        var result = await rangoDbContext.Rangos.FirstOrDefaultAsync(x => x.Id == rangoId);

        if (result == null) return TypedResults.NotFound();

        rangoDbContext.Rangos.Remove(result);

        await rangoDbContext.SaveChangesAsync();

        return TypedResults.NoContent();
    }
}
