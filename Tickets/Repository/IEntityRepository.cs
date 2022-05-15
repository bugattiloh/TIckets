using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tickets.Infrastructure.Models;

namespace Tickets.DataAccess
{
    public interface IEntityRepository<T> where T : class, new()
    {
        Task InsertRangeAsync(IEnumerable<T> entities);
        Task SaveChangesAsync();
    }
}