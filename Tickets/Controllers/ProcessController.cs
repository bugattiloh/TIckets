using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tickets.Infrastructure.Models;

namespace Tickets.Controllers
{
    [Route("[controller]/[action]")]
    public class ProcessController : Controller
    {
        [HttpPost]
        public IActionResult Sale([FromBody]Ticket ticket)
        {
            
            return Ok(ticket);
        }
    }
}