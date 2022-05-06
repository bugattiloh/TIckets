using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tickets.Infrastructure.Models;

namespace Tickets.Infrastructure
{
    public class TicketContext : DbContext
    {
        public TicketContext()
        {
        }

        public TicketContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Ticket> Segments { get; set; }
        public DbSet<RouteSegment> Routes { get; set; }
        public DbSet<Refund> Refunds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(
                    "Host=localhost;Port=5432;Database=ticketdb;Username=postgres;Password=fAP19796");
            }
            
            base.OnConfiguring(optionsBuilder);
        }
        
    }
}