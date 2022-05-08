using AutoMapper;
using Tickets.Infrastructure;
using Tickets.Infrastructure.Models;

namespace Tickets
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<PassengerDto, Passenger>();
            CreateMap<TicketDto, Ticket>();
            CreateMap<RouteSegmentDto, RouteSegment>();
            CreateMap<RefundDto, Refund>();
        }
    }
}