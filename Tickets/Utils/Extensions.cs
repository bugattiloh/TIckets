using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Newtonsoft.Json.Serialization;

namespace Tickets
{
    public static class Extensions
    {
        public static bool IsJsonValid(this string value, Type type)
        {
            var generator = new JSchemaGenerator();
            generator.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var schema = generator.Generate(type);
            schema.AllowAdditionalProperties = false;

            var jObj = JObject.Parse(value);
            return jObj.IsValid(schema);
        }
    }
}