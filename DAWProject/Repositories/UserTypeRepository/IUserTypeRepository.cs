using System;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Repositories.UserTypeRepository
{
    public interface IUserTypeRepository: IGenericRepository<UserType>
    {
        UserType GetByType(string type);
    }
}
