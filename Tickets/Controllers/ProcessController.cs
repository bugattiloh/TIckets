using System.Threading.Tasks;
using BLL.Models.Dto;
using BLL.Models.Tickets.Commands.RefundTicket;
using BLL.Models.Tickets.Commands.SaleTicket;
using BLL.Models.ValidationAttributes.ValidationSchemaAttribute;
using BLL.Service;
using MediatR;
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
        private readonly IMediator _mediator;

        public ProcessController(ISegmentService segmentService, IMediator mediator)
        {
            _segmentService = segmentService;
            _mediator = mediator;
        }
        

        [HttpPost]
        public async Task<IActionResult> Sale([FromBody] TicketDto ticketDto)
        {
            await _mediator.Send(new SaleTicketCommand(ticketDto));
            // await _segmentService.Sale(ticketDto);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Refund([FromBody] RefundDto refundDto)
        {
            await _mediator.Send(new RefundTicketCommand(refundDto));
            // await _segmentService.Refund(refundDto);
            return Ok();
        }
    }
}