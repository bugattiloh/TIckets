using System.Buffers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Tickets
{
    public class CustomBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            bindingContext.HttpContext.Request.EnableBuffering();

            var readResult = await bindingContext.HttpContext.Request.BodyReader.ReadAsync();

            var requestBytes = readResult.Buffer.ToArray();


            if (requestBytes.Length > 2 * 1024)
            {
                bindingContext.ModelState.AddModelError("length", "length failed");
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }

            var requestString = Encoding.UTF8.GetString(requestBytes);

            var isJsonValid = requestString.IsJsonValid(bindingContext.ModelType);

            if (isJsonValid)
            {
                var model = JsonConvert.DeserializeObject(requestString, bindingContext.ModelType);

                bindingContext.Result = ModelBindingResult.Success(model);
            }
            else
            {
                bindingContext.ModelState.AddModelError("schema", "binding failed");
                bindingContext.Result = ModelBindingResult.Failed();
            }
        }
    }
}