using System.Collections.Generic;
using DAWProject.Models;
using DAWProject.Models.DTOs;
using DAWProject.Services.GenericService;

namespace DAWProject.Services.EmployeeService
{
    public interface IEmployeeService : IGenericService<Employee>
    {
    }
}