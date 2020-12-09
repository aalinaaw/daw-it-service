using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Repositories.DatabaseRepository
{
    public interface IDatabaseRepository: IGenericRepository<Model1>
    {
        Model1 GetByTitle(string title);
        List<Model1> GetAllWithInclude();
        List<Model1> GetAllWithJoin();
    }
}
