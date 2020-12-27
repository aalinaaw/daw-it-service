using System;
using DAWProject.Models;
using DAWProject.Models.DTOs;
using DAWProject.Services.ServiceTypeService;
using DAWProject.Services.TicketService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAWProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypeController : ControllerBase
    {
        private readonly IServiceTypeService _serviceTypeService;

        public ServiceTypeController(IServiceTypeService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var serviceTypes = _serviceTypeService.GetAll();
            return Ok(serviceTypes);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TicketDto> Create([FromBody] ServiceTypeDto serviceTypeDto)
        {
            var newServiceType = _serviceTypeService.Create(new ServiceType
            {
                ServiceName = serviceTypeDto.ServiceName
            });
            _serviceTypeService.Save();
            return Ok(newServiceType);
        }
        
        [HttpPut]
        public IActionResult Update(ServiceType serviceType)
        {
            _serviceTypeService.Update(serviceType);
            _serviceTypeService.Save();
            return Ok();
        }
        
        [HttpDelete("{serviceTypeId}")]
        public IActionResult Delete(Guid serviceTypeId)
        {
            _serviceTypeService.Delete(_serviceTypeService.FindById(serviceTypeId));
            _serviceTypeService.Save();
            return Ok();
        }
    }
}