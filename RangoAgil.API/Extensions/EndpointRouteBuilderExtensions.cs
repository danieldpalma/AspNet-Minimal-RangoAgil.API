using RangoAgil.API.EndpointFilters;
using RangoAgil.API.EndpointHandlers;

namespace RangoAgil.API.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static void RegisterRangosEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var rangoEndpoints = endpointRouteBuilder.MapGroup("/rangos");
        var rangosWithIdEndpoints = rangoEndpoints.MapGroup("/{rangoId:int}");

        var rangosWithIdEndEndpointsAndLockFilter = endpointRouteBuilder.MapGroup("/rangos/{rangoId:int}")
            .AddEndpointFilter(new RangoIsLockedFilter(5))
            .AddEndpointFilter(new RangoIsLockedFilter(6))
            .AddEndpointFilter(new RangoIsLockedFilter(11));

        rangoEndpoints.MapGet("", RangosHandlers.GetRangosAsync);

        rangosWithIdEndpoints.MapGet("", RangosHandlers.GetRangoById).WithName("GetRangos");

        rangoEndpoints.MapPost("", RangosHandlers.CreateRangoAsync)
            .AddEndpointFilter<ValidateAnnotationFilter>();

        rangosWithIdEndEndpointsAndLockFilter.MapPut("", RangosHandlers.UpdateRangoAsync);

        rangosWithIdEndEndpointsAndLockFilter.MapDelete("", RangosHandlers.DeleteRangoAsync)
            .AddEndpointFilter<LogNotFoundResponseFilter>();
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
