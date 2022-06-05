using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Models.Tickets.Commands.SaleTicket;
using Infrastructure.Repositories;
using MediatR;
using Models.Db;

namespace BLL.CommandHandlers
{
    public class SaleTicketCommandHandler : IRequestHandler<SaleTicketCommand>
    {
        private readonly ISegmentRepository _repository;
        private readonly IMapper _mapper;

        public SaleTicketCommandHandler(ISegmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(SaleTicketCommand request, CancellationToken cancellationToken)
        {
            var tickets = _mapper.Map<Ticket>(request.TicketDto);
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
                SerialNumber = i,
            }).ToList();
            await _repository.InsertRangeAsync(segments);
            return Unit.Value;
        }
    }
}