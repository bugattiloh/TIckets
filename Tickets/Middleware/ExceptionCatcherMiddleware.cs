using System.Threading.Tasks;
using BLL.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Tickets.Middleware
{
    public class ExceptionCatcherMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionCatcherMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BadHttpRequestException)
            {
                context.Response.StatusCode = 400;
            }
            catch (RefundsWithSameTicketNumberIsNotFoundException ex)
            {
                context.Response.StatusCode = 409;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (JsonSchemaTooLargeException ex)
            {
                context.Response.StatusCode = 413;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is PostgresException {SqlState: PostgresErrorCodes.UniqueViolation})
                {
                    context.Response.StatusCode = 409;
                    await context.Response.WriteAsync("Duplicate error");
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Unknown error");
                }
            }
        }
    }
}