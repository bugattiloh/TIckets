using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private readonly TicketContext _context;

        public ProcessController(TicketContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Sale([FromBody] Ticket ticket)
        {
            var item = _context.Passengers.FirstOrDefault(p => p.TicketNumber == ticket.Passenger.TicketNumber);
            if (item != null)
            {
                return Conflict();
            }

            _context.Add(ticket);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Refund([FromBody] Refund refund)
        {
            var item = _context.Passengers.FirstOrDefault(p => p.TicketNumber == refund.TicketNumber);
            if (item == null)
            {
                return Conflict();
            }

            var segment = _context.Segments.FirstOrDefault(s => s.Passenger.TicketNumber == refund.TicketNumber);
            if (segment != null)
            {
                segment.OperationType = "refund";
            }


            _context.Add(refund);
            _context.SaveChanges();
            return Ok();
        }
    }
}