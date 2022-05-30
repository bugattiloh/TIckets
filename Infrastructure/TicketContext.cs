using Microsoft.EntityFrameworkCore;
using Models.Db;

namespace Infrastructure
{
    public  class TicketContext : DbContext
    {
        public string ConnectionString { get; set; }
        public TicketContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public TicketContext(DbContextOptions options) : base(options)
        {
        }

       
        public DbSet<Segment> Segments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ConnectionString);
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