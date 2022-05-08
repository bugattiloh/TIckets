using System.Collections;
using System.Collections.Generic;
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
            
            context.Add(ticket);

            context.SaveChanges();
            return Ok();
        }
        
        [HttpPost]
        public IActionResult Refund([FromBody] Refund refund)
        {
            var context = new TicketContext();
            
            context.Add(refund);
            
            context.SaveChanges();
            return Ok();
        }
    }
}