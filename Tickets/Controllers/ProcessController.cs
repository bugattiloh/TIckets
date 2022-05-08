using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AutoMapper;
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
            var passenger = _context.Passengers.FirstOrDefault(p => p.TicketNumber == ticketDto.Passenger.TicketNumber);
            if (passenger != null)
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
            var ticket = _context.Tickets.FirstOrDefault(t => t.Passenger.TicketNumber == refundDto.TicketNumber);
            if (ticket == null)
            {
                return Conflict();
            }

            ticket.OperationType = "refund";

            var refund = _mapper.Map<Refund>(refundDto);
            _context.Refunds.Add(refund);
            _context.SaveChanges();
            return Ok();
        }
    }
}