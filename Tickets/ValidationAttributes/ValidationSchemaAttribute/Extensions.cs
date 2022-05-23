using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Serialization;

namespace Tickets.ValidationAttributes.ValidationSchemaAttribute
{
    public static class Extensions
    {
        public static bool IsJsonValid(this string value, Type type)
        {
            var generator = new JSchemaGenerator
            {
                ContractResolver = new DefaultContractResolver() {NamingStrategy = new SnakeCaseNamingStrategy()}
            };

            var schema = generator.Generate(type);
          
            schema.AllowAdditionalProperties = false;

            var jObj = JObject.Parse(value);
            return jObj.IsValid(schema);
        }
    }
}