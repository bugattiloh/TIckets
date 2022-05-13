using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Tickets.Dto;
using Tickets.Infrastructure;
using Tickets.Infrastructure.Models;
using Tickets.Utils;

namespace Tickets.Controllers
{
    [Route("[controller]/[action]")]
    [RequestSizeLimit(2 * 1024)]
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
        [RequestSizeLimit(2 * 1024)]
        [ValidateModel]
        public async Task<IActionResult> Sale([FromBody] TicketDto ticketDto)
        {
            var segments = ticketDto.Routes.Select((route, i) => new Segment()
            {
                Name = ticketDto.Passenger.Name,
                Surname = ticketDto.Passenger.Surname,
                Patronymic = ticketDto.Passenger.Patronymic,
                DocType = ticketDto.Passenger.DocType,
                DocNumber = ticketDto.Passenger.DocNumber,
                Birthdate = ticketDto.Passenger.Birthdate,
                TicketNumber = ticketDto.Passenger.TicketNumber,
                PassengerType = ticketDto.Passenger.PassengerType,
                Gender = ticketDto.Passenger.Gender,
                TicketType = ticketDto.Passenger.TicketType,
                OperationType = ticketDto.OperationType,
                OperationTime = ticketDto.OperationTime,
                OperationPlace = ticketDto.OperationPlace,
                AirlineCode = route.AirlineCode,
                ArriveDatetime = route.ArriveDatetime,
                ArrivePlace = route.ArrivePlace,
                DepartDatetime = route.DepartDatetime,
                DepartPlace = route.DepartPlace,
                FlightNum = route.FlightNum,
                PnrId = route.PnrId,
                SerialNumber = i
            });

            try
            {
                await _context.AddRangeAsync(segments);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return Conflict();
            }

            return Ok();
        }

        [HttpPost]
        [ValidateModel]
        [RequestSizeLimit(2 * 1024)]
        public async Task<IActionResult> Refund([FromBody] RefundDto refundDto)
        {
            var refundSegmentsFromDb = await _context.Segments.Where(s =>
                s.TicketNumber == refundDto.TicketNumber && s.OperationType != "refund").ToListAsync();
            if (refundSegmentsFromDb.Count == 0)
            {
                return Conflict();
            }

            foreach (var segment in refundSegmentsFromDb)
            {
                segment.OperationType = "refund";
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}