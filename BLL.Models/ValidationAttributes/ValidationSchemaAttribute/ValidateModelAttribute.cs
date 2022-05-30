using System.Linq;
using System.Threading.Tasks;
using BLL.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BLL.Models.ValidationAttributes.ValidationSchemaAttribute
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                if (context.ModelState.ContainsKey("schema"))
                {
                    // context.Result = new StatusCodeResult(400);

                    context.Result = new BadRequestObjectResult(
                        string.Join(", ", context.ModelState["schema"].Errors.Select(e => e.ErrorMessage))
                    );
                }

                if (context.ModelState.ContainsKey("size"))
                {
                    throw new JsonSchemaTooLargeException("So large schema");
                    // context.Result = new StatusCodeResult(413);
                }

                return;
            }

            await next.Invoke();
        }
    }
}