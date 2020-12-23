using DAWProject.Helpers;
using DAWProject.Models;
using DAWProject.Models.DTOs;
using DAWProject.Services.EmployeeService;
using DAWProject.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace DAWProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _employeeService.GetAll();
            return Ok(users);
        }
        
        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            _employeeService.Create(employee);
            return Ok();
        }

    }
}
