using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tickets.Infrastructure;
using Tickets.Infrastructure.Models;

namespace Tickets.Controllers
{
    [Route("[controller]/[action]")]
    public class ProcessController : Controller
    {
        [HttpPost]
        public IActionResult Sale([FromBody] Ticket ticket)
        {
            var context = new TicketContext();

            var passenger = ticket.Passenger;
            context.Passengers.Add(passenger);

            context.Segments.Add(ticket);

            foreach (var route in ticket.Routes)
            {
                context.Routes.Add(route);
            }

            context.SaveChanges();
            return Ok();
        }
    }
}