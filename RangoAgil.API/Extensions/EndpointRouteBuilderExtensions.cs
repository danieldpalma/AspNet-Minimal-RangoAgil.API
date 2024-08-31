using Microsoft.AspNetCore.Identity;
using RangoAgil.API.EndpointFilters;
using RangoAgil.API.EndpointHandlers;

namespace RangoAgil.API.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static void RegisterRangosEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapGroup("/identity/").MapIdentityApi<IdentityUser>();

        endpointRouteBuilder.MapGet("/pratos/{pratoId:int}", (int pratoId) => $"O prato {pratoId} é delicioso")
            .WithOpenApi(operation =>
            {
                operation.Deprecated = true;
                return operation;
            })
            .WithSummary("This endpoint is obsolete and will be deprecated in version 2 of this API")
            .WithDescription("Please use other route of this API, beeing /rango/{rangoId}");

        var rangoEndpoints = endpointRouteBuilder.MapGroup("/rangos")
            .RequireAuthorization();

        var rangosWithIdEndpoints = rangoEndpoints.MapGroup("/{rangoId:int}");

        var rangosWithIdEndEndpointsAndLockFilter = endpointRouteBuilder.MapGroup("/rangos/{rangoId:int}")
            .RequireAuthorization("RequireAdminFromBrazil")
            .RequireAuthorization()
            .AddEndpointFilter(new RangoIsLockedFilter(5))
            .AddEndpointFilter(new RangoIsLockedFilter(6))
            .AddEndpointFilter(new RangoIsLockedFilter(11));

        rangoEndpoints.MapGet("", RangosHandlers.GetRangosAsync).WithSummary("This endpoint gets all Rangos.");

        rangosWithIdEndpoints.MapGet("", RangosHandlers.GetRangoById)
            .WithName("GetRangos")
            .AllowAnonymous()
            .WithSummary("This endpoint get a Rango by its Id.");

        rangoEndpoints.MapPost("", RangosHandlers.CreateRangoAsync)
            .AddEndpointFilter<ValidateAnnotationFilter>()
            .WithSummary("This endpoint create a Rango.");

        rangosWithIdEndEndpointsAndLockFilter.MapPut("", RangosHandlers.UpdateRangoAsync)
            .WithSummary("This endpoint update a Rango by its Id.");

        rangosWithIdEndEndpointsAndLockFilter.MapDelete("", RangosHandlers.DeleteRangoAsync)
            .AddEndpointFilter<LogNotFoundResponseFilter>()
            .WithSummary("This endpoint delete a Rango by its Id.");
    }

    public static void RegisterIngredientsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var ingredientsEndpoint = endpointRouteBuilder.MapGroup("/rangos/{rangoId:int}/ingredients")
            .RequireAuthorization();

        ingredientsEndpoint.MapGet("", IngredientsHandlers.GetIngredientsAsync)
            .WithSummary("This endpoint gets all Ingredients of a Rango by its Id.");;

        ingredientsEndpoint.MapPost("", () =>
        {
            throw new NotImplementedException();
        });
    }
}
