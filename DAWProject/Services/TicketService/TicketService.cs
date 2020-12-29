using System;
using System.Collections.Generic;
using System.Linq;
using DAWProject.Models;
using DAWProject.Models.DTOs;
using DAWProject.Repositories.TicketAuditEntryRepository;
using DAWProject.Repositories.TicketRepository;
using DAWProject.Services.EmployeeService;
using DAWProject.Services.UserService;

namespace DAWProject.Services.TicketService
{
    public class TicketService: ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketAuditEntryRepository _ticketAuditEntryRepository;
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;

        public TicketService(ITicketRepository ticketRepository, ITicketAuditEntryRepository ticketAuditEntryRepository, IEmployeeService employeeService, IUserService userService)
        {
            _ticketRepository = ticketRepository;
            _ticketAuditEntryRepository = ticketAuditEntryRepository;
            _employeeService = employeeService;
            _userService = userService;
        }

        public Ticket CreateNewTicket(TicketDto ticketDto)
        {
            var newTicket = _ticketRepository.Create(new Ticket
            {
                Description = ticketDto.Description,
                TicketTypeId = ticketDto.TicketType.Id,
                User = _userService.GetById(ticketDto.UserId),
                Status = "In Progress"
            });
            _ticketAuditEntryRepository.Create(new TicketAuditEntry
            {
                CreationDate = DateTime.Now,
                TicketId = newTicket.Id
            });
            var employees = _employeeService.GetAll().ToList();
            var empIds = employees.Select(employee => employee.Id).ToArray();
            
            var random = new Random();
            // get a random count of employee to assign to the ticket
            var employeeCount = random.Next(1, employees.Count());
            
            // select which employees
            var employeeTickets = new List<EmployeeTicket>();
            for (var i = 0; i < employeeCount; i++)
            {
                // get a random employee
                var r = random.Next(empIds.Length);
                employeeTickets.Add(new EmployeeTicket
                {
                    EmployeeId = empIds[r], 
                    TicketId = newTicket.Id
                });
            }
            
            foreach (var id in empIds)
            {
                var employee = _employeeService.FindById(id);
                employee.Tickets = employeeTickets.Where(et => et.EmployeeId.Equals(id)).ToList();
                _employeeService.Update(employee);
            }

            _employeeService.Save();

            newTicket.Employees = employeeTickets;
            newTicket = _ticketRepository.Update(newTicket);
            _ticketRepository.Save();

            return newTicket;
        }

        public Ticket GetById(Guid ticketId)
        {
            return _ticketRepository.FindById(ticketId);
        }

        public void DeleteTicket(Ticket ticket)
        {
            _ticketRepository.Delete(ticket);
        }

        public void Save()
        {
            _ticketRepository.Save();
        }

        public void Update(Ticket ticket)
        {
            _ticketRepository.Update(ticket);
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _ticketRepository.GetAllAsQueryable();
        }

        public IEnumerable<Ticket> GetAllTicketsByEmployeeId(Guid employeeId)
        {
            return _ticketRepository.FindByEmployee(_employeeService.FindById(employeeId));
        }

        public IEnumerable<Ticket> GetAllTicketsByUser(Guid userId)
        {
            return _ticketRepository.FindByUser(_userService.GetById(userId));
        }
    }
}