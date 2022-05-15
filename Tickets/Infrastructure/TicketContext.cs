using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Tickets.Infrastructure.Models;

namespace Tickets.Infrastructure
{
    public  class TicketContext : DbContext
    {
        public TicketContext()
        {
        }

        public TicketContext(DbContextOptions options) : base(options)
        {
        }

       
        public DbSet<Segment> Segments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(
                    "Host=localhost;Port=5432;Database=ticketdb;Username=postgres;Password=fAP19796");
            }
            
            base.OnConfiguring(optionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Segment>()
                .HasIndex(s => new { s.TicketNumber, s.SerialNumber })
                .IsUnique();
        }
        
    }
}