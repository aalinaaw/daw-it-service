using System;
using System.Linq;
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
            return Ok(tickets);
        }
        
        [HttpGet("user/{id}")]
        public IActionResult GetByUser(Guid id)
        {
            var tickets = _ticketService.GetAllTicketsByUser(id).ToList();
            return Ok(tickets);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TicketDto> Create(TicketDto ticketDto)
        {
            var ticket = _ticketService.CreateNewTicket(ticketDto);
            return Ok(ticket);
        }
    }
}