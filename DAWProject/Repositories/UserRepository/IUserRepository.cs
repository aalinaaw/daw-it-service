using System;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Repositories.UserRepository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        User GetByUsername(string username);
    }
}
