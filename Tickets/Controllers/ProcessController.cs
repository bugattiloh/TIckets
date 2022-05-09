using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tickets.Infrastructure;
using Tickets.Infrastructure.Models;

namespace Tickets.Controllers
{
    [Route("[controller]/[action]")]
    public class ProcessController : Controller
    {
        private readonly TicketContext _context;
        private readonly IMapper _mapper;

        public ProcessController(TicketContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        [ValidateModel]
        public IActionResult Sale([FromBody] TicketDto ticketDto)
        {
            var ticketFromDb = _context.Tickets.FirstOrDefault(t =>
                t.Passenger.TicketNumber == ticketDto.Passenger.TicketNumber && t.OperationType != "refund");
            if (ticketFromDb != null)
            {
                return Conflict();
            }

            var ticket = _mapper.Map<Ticket>(ticketDto);
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [ValidateModel]
        public IActionResult Refund([FromBody] RefundDto refundDto)
        {
            var refundFromDb = _context.Refunds.FirstOrDefault(r => r.TicketNumber == refundDto.TicketNumber);
            var ticketFromDb = _context.Tickets.FirstOrDefault(t => t.Passenger.TicketNumber == refundDto.TicketNumber);
            if (ticketFromDb == null || refundFromDb != null)
            {
                return Conflict();
            }

            ticketFromDb.OperationType = "refund";

            var refund = _mapper.Map<Refund>(refundDto);
            _context.Refunds.Add(refund);
            _context.SaveChanges();
            return Ok();
        }
    }
}