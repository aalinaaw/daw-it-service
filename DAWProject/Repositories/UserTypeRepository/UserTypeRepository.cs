using System;
using System.Linq;
using DAWProject.Data;
using DAWProject.Models;
using DAWProject.Repositories.GenericRepository;

namespace DAWProject.Repositories.UserTypeRepository
{
    public class UserTypeRepository: GenericRepository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository (DawAppContext context) : base(context)
        {

        }

        public UserType GetByType(string type)
        {
            return Table.SingleOrDefault(userType => userType.Type.Equals(type));
        }
    }
}
