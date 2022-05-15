using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tickets.Infrastructure;
using Tickets.Infrastructure.Models;

namespace Tickets.DataAccess
{
    public class SegmentRepository : ISegmentRepository
    {
        private readonly TicketContext _context;

        public SegmentRepository(TicketContext context)
        {
            _context = context;
        }

        public virtual async Task InsertRangeAsync(IEnumerable<Segment> segments)
        {
            await _context.Segments.AddRangeAsync(segments);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Segment>> FindRefundSegmentsWithSameTicketNumberAsync(string ticketNumber)
        {
            return await _context.Segments
                .Where(s => s.TicketNumber == ticketNumber && s.OperationType != "refund")
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}