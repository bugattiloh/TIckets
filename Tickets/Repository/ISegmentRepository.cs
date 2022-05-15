using System.Collections.Generic;
using System.Threading.Tasks;
using Tickets.Infrastructure.Models;

namespace Tickets.DataAccess
{
    public interface ISegmentRepository : IEntityRepository<Segment>
    {
        Task<ICollection<Segment>> FindRefundSegmentsWithSameTicketNumberAsync(string str);
    }
}