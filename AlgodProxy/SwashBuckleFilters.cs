using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;

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


    public class SwaggerAddAliasFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext schemaFilterContext)
        {
            if (schemaFilterContext.MemberInfo != null)
            {

                schema.Extensions["x-algorand-longname"] = new OpenApiString(schemaFilterContext.MemberInfo.Name);

            }
            
           
        }
    }




    public class AnnotationsDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
           
        }

    
    }
}
