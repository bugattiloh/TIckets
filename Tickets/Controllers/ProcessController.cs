using System.Threading.Tasks;
using BLL.Models.Dto;
using BLL.Models.ValidationAttributes.ValidationSchemaAttribute;
using BLL.Service;
using Microsoft.AspNetCore.Mvc;


namespace Tickets.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]/[action]")]
    [ValidateModel]
    [RequestSizeLimit(2 * 1024)]
    public class ProcessController : Controller
    {
        private readonly ISegmentService _segmentService;

        public ProcessController(ISegmentService segmentService)
        {
            _segmentService = segmentService;
        }


        [HttpPost]
        public async Task<IActionResult> Sale([FromBody] TicketDto ticketDto)
        {
            var responseSale = await _segmentService.Sale(ticketDto);

            if (responseSale._responseCode == 409)
            {
                return Conflict(responseSale._message);
            }

            if (responseSale._responseCode == 400)
            {
                return BadRequest(responseSale._message);
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Refund([FromBody] RefundDto refundDto)
        {
            var responseRefund = await _segmentService.Refund(refundDto);

            if (responseRefund._responseCode == 409)
            {
                return Conflict(responseRefund._message);
            }

            return Ok();
        }
    }
}