using AutoMapper;
using BLL.Models.Dto;
using Models.Db;

namespace BLL
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<TicketDto, Ticket>();
            CreateMap<PassengerDto, Passenger>();
            CreateMap<RouteDto, Route>();
            CreateMap<RefundDto, Refund>();
        }
    }
}