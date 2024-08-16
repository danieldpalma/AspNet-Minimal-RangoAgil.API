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

app.MapGet("/", () => "Hello World!");

app.MapGet("/rangos", async Task<Results<NoContent, Ok<IEnumerable<RangoDTO>>>>
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

app.MapGet("/rango/{id:int}", async (RangoDbContext rangoDbContext, IMapper mapper, int id) =>
{
    return mapper.Map<RangoDTO>(await rangoDbContext.Rangos.FirstOrDefaultAsync(x => x.Id == id));
});

app.MapGet("rango/{rangoId:int}/ingredientes", async (
        RangoDbContext rangoDbContext,
        IMapper mapper,
        int rangoId) =>
{
    return mapper.Map<IEnumerable<IngredientDTO>>
    (
        (
            await rangoDbContext.Rangos
                               .Include(rango => rango.Ingredients)
                               .FirstOrDefaultAsync(rango => rango.Id == rangoId)
         )?.Ingredients    
    );
});

app.Run();
