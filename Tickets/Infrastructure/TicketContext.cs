using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Tickets.Infrastructure.Models;

namespace Tickets.Infrastructure
{
    public  class TicketContext : DbContext
    {
        private IConfiguration _configuration;
        public TicketContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TicketContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

       
        public DbSet<Segment> Segments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(
                    _configuration["ConnectionString"]);
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