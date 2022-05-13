using AutoMapper;
using Tickets.Dto;
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
            CreateMap<RouteDto, Route>();
            CreateMap<RefundDto, Refund>();
        }
    }
}