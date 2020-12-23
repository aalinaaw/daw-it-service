using DAWProject.Data;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Repositories.EmployeeRepository
{
    public class EmployeeRepository: GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DawAppContext dbContext) : base(dbContext)
        {
        }
    }
}