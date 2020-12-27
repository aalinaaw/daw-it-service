using System;
using System.Collections.Generic;
using DAWProject.Models;
using DAWProject.Models.DTOs;

namespace DAWProject.Services.TicketService
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetAllTickets();
        
        IEnumerable<Ticket> GetAllTicketsByEmployeeId(Guid employeeId);
        
        IEnumerable<Ticket> GetAllTicketsByUser(Guid id);

        Ticket CreateNewTicket(TicketDto ticketDto);
        Ticket GetById(Guid ticketId);
        void DeleteTicket(Ticket getById);
        void Save();
        void Update(Ticket ticket);
    }
}