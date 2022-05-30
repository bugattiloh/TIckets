using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BLL.Models.ValidationAttributes.ValidationSchemaAttribute
{
    public class CustomBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            bindingContext.HttpContext.Request.EnableBuffering();

            var memoryStream = new MemoryStream();

            await bindingContext.HttpContext.Request.Body.CopyToAsync(memoryStream);
            var requestBytes = memoryStream.ToArray();

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
    }
}