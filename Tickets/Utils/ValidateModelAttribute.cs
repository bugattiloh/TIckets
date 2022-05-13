using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Tickets.Utils
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
                    context.Result = new StatusCodeResult(413);
                }

                return;
            }

            await next.Invoke();
        }
    }
}