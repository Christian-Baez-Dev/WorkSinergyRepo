using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WorkSynergy.WebApi.Filters
{

    public class FromRouteOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null) return;

            // Encuentra parámetros en el modelo que provienen de la ruta
            foreach (var parameter in operation.Parameters)
            {
                var descriptor = context.ApiDescription.ParameterDescriptions
                    .FirstOrDefault(p => p.Name == parameter.Name);

                if (descriptor?.Source?.Id == "Route")
                {
                    parameter.In = ParameterLocation.Path; // Cambiar ubicación a "path"
                }
            }
        }
    }
}
