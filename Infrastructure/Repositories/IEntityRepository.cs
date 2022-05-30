using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IEntityRepository<T> where T : class, new()
    {
        Task InsertRangeAsync(IEnumerable<T> entities);
        Task SaveChangesAsync();
    }
}