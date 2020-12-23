using DAWProject.Data;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Repositories.ServiceTypeRepository
{
    public class ServiceTypeRepository: GenericRepository<ServiceType>, IServiceTypeRepository
    {
        public ServiceTypeRepository(DawAppContext dbContext) : base(dbContext)
        {
        }
    }
}