using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Tickets.Middleware.Exceptions;

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
            catch (DbUpdateException)
            {
                context.Response.StatusCode = 409;
            }
        }
    }
}