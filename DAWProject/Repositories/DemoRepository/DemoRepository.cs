using DAWProject.Data;
using DAWProject.Models;
using System.Threading.Tasks;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Repositories.AccessoryRepository
{
    public class DemoRepository : GenericRepository<DataBaseModel>, IDemoRepository
    {
        public DemoRepository(DawAppContext dbContext) : base(dbContext)
        {
        }
    }
}