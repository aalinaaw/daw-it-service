using DAWProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DAWProject.Data
{
    public class DawAppContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTicket> EmployeeTickets { get; set; }

        public DawAppContext(DbContextOptions<DawAppContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany<Ticket>(u => u.Tickets)
                .WithOne(t => t.User);
            
            builder.Entity<EmployeeTicket>()
                .HasKey(et => new { et.EmployeeId, et.TicketId });
            builder.Entity<EmployeeTicket>()
                .HasOne(et => et.Employee)
                .WithMany(e => e.Tickets)
                .HasForeignKey(et => et.EmployeeId);  
            builder.Entity<EmployeeTicket>()
                .HasOne(et => et.Ticket)
                .WithMany(e => e.Employees)
                .HasForeignKey(et => et.TicketId);  

            builder.Entity<Ticket>()
                .HasOne(p => p.TicketType)
                .WithMany(type => type.Tickets)
                .HasForeignKey(ticket => ticket.TicketTypeId);

            base.OnModelCreating(builder);
        }
    }
}