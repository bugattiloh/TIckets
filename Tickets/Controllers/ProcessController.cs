using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tickets.DataAccess;
using Tickets.Dto;
using Tickets.Infrastructure.Models;
using Tickets.Utils;

namespace Tickets.Controllers
{
    [Route("[controller]/[action]")]
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
                await _repository.InsertRangeAsync(segments);
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
            // var refund = _mapper.Map<Refund>(refundDto);
            
            var refundSegmentsFromDb =
                await _repository.FindRefundSegmentsWithSameTicketNumberAsync(refundDto.TicketNumber);
            if (refundSegmentsFromDb.Count == 0)
            {
                return Conflict();
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