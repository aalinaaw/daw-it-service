using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Repositories.TicketAuditEntryRepository
{
    public interface ITicketAuditEntryRepository: IGenericRepository<TicketAuditEntry>
    {
        TicketAuditEntry FindByTicket(Ticket ticket);
    }
}