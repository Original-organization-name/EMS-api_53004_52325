using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EMS.Shared.Filters;

public class RequiredSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        foreach (var prop in schema.Properties.Where(x => !x.Value.Nullable && !schema.Required.Contains(x.Key)))
        {
            schema.Required.Add(prop.Key);
        }
    }
}