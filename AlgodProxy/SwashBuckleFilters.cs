using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using System.Reflection;

namespace AlgodProxy
{
    internal static class StringExtensions
    {
        internal static string ToCamelCase(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return char.ToLowerInvariant(value[0]) + value.Substring(1);
        }
    }
    public class SwaggerIgnoreFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext schemaFilterContext)
        {
      
            var keys = new System.Collections.Generic.List<string>();
            var prefix = "Org.BouncyCastle.";
            foreach (var key in schemaFilterContext.SchemaRepository.Schemas.Keys)
            {
                if (key.StartsWith(prefix))
                {
                    keys.Add(key);
                }
            }
            foreach (var key in keys)
            {
                schemaFilterContext.SchemaRepository.Schemas.Remove(key);
            }
        }
    }
}
