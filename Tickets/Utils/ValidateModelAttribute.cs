using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Tickets
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                if (context.ModelState.ContainsKey("schema"))
                {
                    context.Result = new StatusCodeResult(400);
                }
                else if (context.ModelState.ContainsKey("length"))
                {
                    context.Result = new StatusCodeResult(413);
                }

                return;
            }

            await next.Invoke();
        }
    }
}