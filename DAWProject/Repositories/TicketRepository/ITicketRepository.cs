using System.Collections.Generic;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Repositories.TicketRepository
{
    public interface ITicketRepository: IGenericRepository<Ticket>
    {
        IEnumerable<Ticket> FindByEmployee(Employee employee);
        
        IEnumerable<Ticket> FindByUser(User user);
    }
}