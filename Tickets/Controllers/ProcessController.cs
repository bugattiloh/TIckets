﻿using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tickets.Dto;
using Tickets.Infrastructure.Models;
using Tickets.Middleware.Exceptions;
using Tickets.Repository;
using Tickets.ValidationAttributes.ValidationSchemaAttribute;


namespace Tickets.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]/[action]")]
    [ValidateModel]
    [RequestSizeLimit(2 * 1024)]
    public class ProcessController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISegmentRepository _repository;

        public ProcessController(IMapper mapper, ISegmentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }


        [HttpPost]
        public async Task<IActionResult> Sale([FromBody] TicketDto ticketDto)
        {
            var tickets = _mapper.Map<Ticket>(ticketDto);
            var segments = tickets.Routes.Select((route, i) => new Segment()
            {
                Name = tickets.Passenger.Name,
                Surname = tickets.Passenger.Surname,
                Patronymic = tickets.Passenger.Patronymic,
                DocType = tickets.Passenger.DocType,
                DocNumber = tickets.Passenger.DocNumber,
                Birthdate = tickets.Passenger.Birthdate,
                TicketNumber = tickets.Passenger.TicketNumber,
                PassengerType = tickets.Passenger.PassengerType,
                Gender = tickets.Passenger.Gender,
                TicketType = tickets.Passenger.TicketType,
                OperationType = tickets.OperationType,
                OperationTime = tickets.OperationTime,
                OperationPlace = tickets.OperationPlace,
                AirlineCode = route.AirlineCode,
                ArriveDatetime = route.ArriveDatetime,
                ArrivePlace = route.ArrivePlace,
                DepartDatetime = route.DepartDatetime,
                DepartPlace = route.DepartPlace,
                FlightNum = route.FlightNum,
                PnrId = route.PnrId,
                SerialNumber = i
            });

            await _repository.InsertRangeAsync(segments);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Refund([FromBody] RefundDto refundDto)
        {
            var refund = _mapper.Map<Refund>(refundDto);

            var refundSegmentsFromDb =
                await _repository.FindRefundSegmentsWithSameTicketNumberAsync(refund.TicketNumber);
            if (refundSegmentsFromDb.Count == 0)
            {
                throw new RefundsWithSameTicketNumberIsNotFoundException("There are not refunds with same TicketNumber ");
            }

            foreach (var segment in refundSegmentsFromDb)
            {
                segment.OperationType = "refund";
            }

            await _repository.SaveChangesAsync();
            return Ok();
        }
    }
}