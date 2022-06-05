using BLL.Models.Dto;
using MediatR;


namespace BLL.Models.Tickets.Commands.SaleTicket
{
    public class SaleTicketCommand : IRequest
    {
        public TicketDto TicketDto { get; set; }

        public SaleTicketCommand(TicketDto ticketDto)
        {
            TicketDto = ticketDto;
        }
    }
}