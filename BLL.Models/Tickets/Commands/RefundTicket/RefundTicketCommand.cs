using BLL.Models.Dto;
using MediatR;

namespace BLL.Models.Tickets.Commands.RefundTicket
{
    public class RefundTicketCommand: IRequest
    {
        public RefundDto RefundDto { get; set; }

        public RefundTicketCommand(RefundDto refundDto)
        {
            RefundDto = refundDto;
        }
    }
}