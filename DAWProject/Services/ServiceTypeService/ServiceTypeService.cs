using DAWProject.Models;
using DAWProject.Repositories.ServiceTypeRepository;
using DAWProject.Services.GenericService;

namespace DAWProject.Services.ServiceTypeService
{
    public class ServiceTypeService: GenericService<ServiceType>,IServiceTypeService
    {
        public ServiceTypeService(IServiceTypeRepository serviceTypeRepository) : base(serviceTypeRepository)
        {
        }
    }
}