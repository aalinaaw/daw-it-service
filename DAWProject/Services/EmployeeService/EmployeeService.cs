using DAWProject.Models;
using DAWProject.Repositories.EmployeeRepository;
using DAWProject.Services.GenericService;

namespace DAWProject.Services.EmployeeService
{
    public class EmployeeService: GenericService<Employee>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
        }
    }
}