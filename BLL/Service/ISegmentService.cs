using System.Threading.Tasks;
using BLL.Models.Dto;

namespace BLL.Service
{
    public interface ISegmentService
    {
        Task Sale(TicketDto ticketDto);
        Task Refund(RefundDto refundDto);
    }
}