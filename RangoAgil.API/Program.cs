using Microsoft.EntityFrameworkCore;
using RangoAgil.API.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RangoDbContext>(
    options => options.UseSqlite(builder.Configuration["ConnectionStrings:RangoDbConStr"])
    );

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
