using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Db;

namespace Infrastructure.Repositories
{
    public interface ISegmentRepository : IEntityRepository<Segment>
    {
        Task<ICollection<Segment>> FindRefundSegmentsWithSameTicketNumberAsync(string str);
        
    }
}