
using MiniValidation;
using RangoAgil.API.Models;

namespace RangoAgil.API.EndpointFilters;

public class ValidateAnnotationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var rangoForCreateDTO = context.GetArgument<RangoForCreateDTO>(2);

        if(!MiniValidator.TryValidate(rangoForCreateDTO, out var validationErros))
        {
            return TypedResults.ValidationProblem(validationErros);
        };

        return await next(context);
    }
}
