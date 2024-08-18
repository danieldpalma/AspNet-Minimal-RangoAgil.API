using RangoAgil.API.EndpointHandlers;

namespace RangoAgil.API.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static void RegisterRangosEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var rangoEndpoints = endpointRouteBuilder.MapGroup("/rangos");
        var rangoscomIdEndpoints = rangoEndpoints.MapGroup("/{rangoId:int}");

        rangoEndpoints.MapGet("", RangosHandlers.GetRangosAsync);

        rangoscomIdEndpoints.MapGet("", RangosHandlers.GetRangoById).WithName("GetRangos");

        rangoEndpoints.MapPost("", RangosHandlers.CreateRangoAsync);

        rangoscomIdEndpoints.MapPut("", RangosHandlers.UpdateRangoAsync);

        rangoscomIdEndpoints.MapDelete("", RangosHandlers.DeleteRangoAsync);
    }

    public static void RegisterIngredientsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var ingredientsEndpoint = endpointRouteBuilder.MapGroup("/rangos/{rangoId:int}/ingredients");

        ingredientsEndpoint.MapGet("", IngredientsHandlers.GetIngredientsAsync);

        ingredientsEndpoint.MapPost("", () =>
        {
            throw new NotImplementedException();
        });
    }
}
