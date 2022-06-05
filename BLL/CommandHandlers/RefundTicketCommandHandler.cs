using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Models.Exceptions;
using BLL.Models.Tickets.Commands.RefundTicket;
using Infrastructure.Repositories;
using MediatR;
using Models.Db;

namespace BLL.CommandHandlers
{
    public class RefundTicketCommandHandler : IRequestHandler<RefundTicketCommand>
    {
        private ISegmentRepository _repository;
        private IMapper _mapper;

        public RefundTicketCommandHandler(IMapper mapper, ISegmentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(RefundTicketCommand request, CancellationToken cancellationToken)
        {
            var refund = _mapper.Map<Refund>(request.RefundDto);
            var refundSegmentsFromDb =
                await _repository.FindRefundSegmentsWithSameTicketNumberAsync(refund.TicketNumber);
            if (refundSegmentsFromDb.Count == 0)
            {
                throw new RefundsWithSameTicketNumberIsNotFoundException("Duplicate error");
            }

            foreach (var segment in refundSegmentsFromDb)
            {
                segment.OperationType = "refund";
            }

            await _repository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}