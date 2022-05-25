using System.Buffers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Tickets.ValidationAttributes.ValidationSchemaAttribute
{
    public class CustomBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            try
            {
                bindingContext.HttpContext.Request.EnableBuffering();

                var readResult = await bindingContext.HttpContext.Request.BodyReader.ReadAsync();

                var requestBytes = readResult.Buffer.ToArray();

                var requestString = Encoding.UTF8.GetString(requestBytes);

                var isJsonValid = requestString.IsJsonValid(bindingContext.ModelType);

                if (isJsonValid)
                {
                    var model = JsonConvert.DeserializeObject(requestString, bindingContext.ModelType,
                        new JsonSerializerSettings()
                        {
                            ContractResolver = new DefaultContractResolver()
                            {
                                NamingStrategy = new SnakeCaseNamingStrategy()
                            }
                        });

                    bindingContext.Result = ModelBindingResult.Success(model);
                }
                else
                {
                    bindingContext.ModelState.AddModelError("schema", "schema invalid");
                    bindingContext.Result = ModelBindingResult.Failed();
                }
            }
            catch (BadHttpRequestException)
            {
            }
        }
    }
}