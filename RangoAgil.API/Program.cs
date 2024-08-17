using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RangoAgil.API.DbContexts;
using RangoAgil.API.Entities;
using RangoAgil.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RangoDbContext>(
    options => options.UseSqlite(builder.Configuration["ConnectionStrings:RangoDbConStr"])
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

var rangoEndpoints = app.MapGroup("/rangos");
var rangoscomIdEndpoints = rangoEndpoints.MapGroup("/{rangoId:int}");
var ingredientsEndpoint = rangoscomIdEndpoints.MapGroup("/ingredients");

rangoEndpoints.MapGet("", async Task<Results<NoContent, Ok<IEnumerable<RangoDTO>>>>
    (RangoDbContext rangoDbContext,
    IMapper mapper,
    [FromQuery(Name = "name")] string? name) =>
{

    var result = await rangoDbContext.Rangos
                                .Where(x => name == null || x.Name.ToLower().Contains(name.ToLower()))
                                .ToListAsync();

    if (result.Count <= 0 || result == null) return TypedResults.NoContent();

    return TypedResults.Ok(mapper.Map<IEnumerable<RangoDTO>>(result));
});


ingredientsEndpoint.MapGet("", async Task<Results<NotFound, Ok<IEnumerable<IngredientDTO>>>> (
        RangoDbContext rangoDbContext,
        IMapper mapper,
        int rangoId) =>
{
    var result = await rangoDbContext.Rangos
                               .Include(rango => rango.Ingredients)
                               .FirstOrDefaultAsync(rango => rango.Id == rangoId);

    if(result == null) return TypedResults.NotFound();

    return TypedResults.Ok(mapper.Map<IEnumerable<IngredientDTO>>
    (
        (
            await rangoDbContext.Rangos
                               .Include(rango => rango.Ingredients)
                               .FirstOrDefaultAsync(rango => rango.Id == rangoId)
         )?.Ingredients
    ));
});

rangoscomIdEndpoints.MapGet("", async Task<Results<NotFound, Ok<RangoDTO>>> 
    (RangoDbContext rangoDbContext, 
    IMapper mapper, 
    int rangoId) =>
{
    var result = await rangoDbContext.Rangos.FirstOrDefaultAsync(x => x.Id == rangoId);

    if (result == null) return TypedResults.NotFound();

    return TypedResults.Ok(mapper.Map<RangoDTO>(result));
}).WithName("GetRangos");

rangoEndpoints.MapPost("", async Task<CreatedAtRoute<RangoDTO>>
    (RangoDbContext rangoDbContext,
    IMapper mapper,
    [FromBody] RangoForCreateDTO rangoForCreateDTO
    ) =>
{
    var result = mapper.Map<Rango>(rangoForCreateDTO);
    rangoDbContext.Add(result);
    await rangoDbContext.SaveChangesAsync();

    var rangoToReturn = mapper.Map<RangoDTO>(result);

    return TypedResults.CreatedAtRoute(rangoToReturn, "GetRangos", new { rangoId = rangoToReturn.Id });

});

rangoscomIdEndpoints.MapPut("", async Task<Results<NotFound, Ok>>(
        RangoDbContext rangoDbContext,
        IMapper mapper,
        int rangoId,
        [FromBody] RangoForUpdateDTO rangoForUpdateDTO) =>
{
    var result = await rangoDbContext.Rangos.FirstOrDefaultAsync(x => x.Id == rangoId);

    if (result == null) return TypedResults.NotFound();

    mapper.Map(rangoForUpdateDTO, result);

    await rangoDbContext.SaveChangesAsync();

    return TypedResults.Ok();
});

rangoscomIdEndpoints.MapDelete("", async Task<Results<NotFound, NoContent>>(
        RangoDbContext rangoDbContext,
        int rangoId) =>
{
    var result = await rangoDbContext.Rangos.FirstOrDefaultAsync(x => x.Id == rangoId);

    if (result == null) return TypedResults.NotFound();

    rangoDbContext.Rangos.Remove(result);
    
    await rangoDbContext.SaveChangesAsync();

    return TypedResults.NoContent();
});

app.Run();
