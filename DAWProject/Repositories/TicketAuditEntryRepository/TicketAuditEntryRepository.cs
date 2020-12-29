using System;
using System.Linq;
using DAWProject.Data;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Repositories.TicketAuditEntryRepository
{
    public class TicketAuditEntryRepository : GenericRepository<TicketAuditEntry>, ITicketAuditEntryRepository
    {
        public TicketAuditEntryRepository(DawAppContext dbContext) : base(dbContext)
        {
        }

        public TicketAuditEntry FindByTicket(Ticket ticket)
        {
            return Table.SingleOrDefault(tae => tae.TicketId.Equals(ticket.Id));
        }
    }
}