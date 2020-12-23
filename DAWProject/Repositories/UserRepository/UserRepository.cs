using System;
using System.Linq;
using DAWProject.Data;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Repositories.UserRepository
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository (DawAppContext context) : base(context)
        {

        }

        public User GetByUsername(string username)
        {
            return Table.SingleOrDefault(user => user.Username == username);
        }
    }
}
