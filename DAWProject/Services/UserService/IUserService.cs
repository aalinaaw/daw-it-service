using DAWProject.Models;
using DAWProject.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAWProject.Services.UserService
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(Guid id);

        void CreateUser(UserDto userDto);
        List<UserType> GetAllUserTypes();

        void CreateUserType(UserType userType);
    }
}
