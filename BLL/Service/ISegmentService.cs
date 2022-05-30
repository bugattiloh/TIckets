using System.Threading.Tasks;
using BLL.Models.Dto;

namespace BLL.Service
{
    public interface ISegmentService
    {
        Task<BaseResponse> Sale(TicketDto ticketDto);
        Task<BaseResponse> Refund(RefundDto refundDto);
    }
}