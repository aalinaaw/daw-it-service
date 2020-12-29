using System;
using System.Collections.Generic;
using System.Linq;
using DAWProject.Models;
using DAWProject.Models.DTOs;
using DAWProject.Services.TicketService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAWProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var tickets = _ticketService.GetAllTickets().ToList();
            return Ok(tickets);
        }
        
        [HttpGet("employee/{id}")]
        public IActionResult GetByEmployee(Guid id)
        {
            var tickets = _ticketService.GetAllTicketsByEmployeeId(id).ToList();
            var ticketDtos = mapTicketDtos(tickets);
            return Ok(ticketDtos);
        }
        
        [HttpGet("user/{id}")]
        public IActionResult GetByUser(Guid id)
        {
            var tickets = _ticketService.GetAllTicketsByUser(id).ToList();
            var ticketDtos = mapTicketDtos(tickets);
            return Ok(ticketDtos);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TicketDto> Create(TicketDto ticketDto)
        {
            var ticket = _ticketService.CreateNewTicket(ticketDto);
            return Ok(ticket);
        }
        
        public IActionResult Update(TicketDto ticketDto)
        {

            var ticket = _ticketService.GetById(ticketDto.Id);
            ticket.Status = ticketDto.Status;
            _ticketService.Update(ticket);
            _ticketService.Save();
            return Ok();
        } 
        
        [HttpDelete("{ticketId}")]
        public IActionResult Delete(Guid ticketId)
        {
            
            _ticketService.DeleteTicket(_ticketService.GetById(ticketId));
            _ticketService.Save();
            return Ok();
        }

        private List<TicketDto> mapTicketDtos(List<Ticket> tickets)
        {
            var ticketDtos = new List<TicketDto>();
            foreach (var ticket in tickets)
            {
                ticketDtos.Add(new TicketDto
                {
                    Id = ticket.Id,
                    Description = ticket.Description,
                    TicketType = ticket.TicketType,
                    Status = ticket.Status,
                    UserId = ticket.UserId,
                    Username = ticket.User.Username,
                    Employees = ticket.Employees.Select(employeeTicket => employeeTicket.Employee).ToList(),
                    AuditEntry= ticket.TicketAuditEntry
                });
            }

            return ticketDtos;
        }
    }
}