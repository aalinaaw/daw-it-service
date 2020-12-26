using System.Linq;
using DAWProject.Data;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DAWProject.Repositories.UserRepository
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository (DawAppContext context) : base(context)
        {

        }

        public override IQueryable<User> GetAllAsQueryable()
        {
            return Table.Include(user => user.UserType)
                .Include(user => user.Tickets);
        }

        public User GetByUsername(string username)
        {
            return Table.SingleOrDefault(user => user.Username == username);
        }
    }
}
