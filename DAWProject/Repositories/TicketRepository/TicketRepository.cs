using System.Collections.Generic;
using System.Linq;
using DAWProject.Data;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DAWProject.Repositories.TicketRepository
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(DawAppContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Ticket> GetAllAsQueryable()
        {
            return Table.Include(t => t.TicketType)
                .Include(t => t.Employees)
                    .ThenInclude(et => et.Employee)
                .Include(t => t.Employees)
                    .ThenInclude(et => et.Ticket);
        }

        public IEnumerable<Ticket> FindByUser(User user)
        {
            return Table.Where(ticket => ticket.UserId.Equals(user.Id))
                .Include(ticket => ticket.Employees)
                    .ThenInclude(et => et.Employee)
                .Include(ticket => ticket.TicketType)
                .Include(ticket => ticket.User);;
        }

        public IEnumerable<Ticket> FindByEmployee(Employee employee)
        {
            return Table.Where(ticket =>
                ticket.Employees.Any(employeeTicket => employeeTicket.EmployeeId.Equals(employee.Id)))
                .Include(ticket => ticket.Employees)
                .Include(ticket => ticket.TicketType)
                .Include(ticket => ticket.User)
                .Include(ticket => ticket.TicketAuditEntry);
        }
    }
}