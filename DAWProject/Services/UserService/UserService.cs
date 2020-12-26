using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DAWProject.Helpers;
using DAWProject.Models;
using DAWProject.Models.Base;
using DAWProject.Models.DTOs;
using DAWProject.Repositories.UserRepository;
using DAWProject.Repositories.UserTypeRepository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DAWProject.Services.UserService
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserTypeRepository _userTypeRepository;

        public UserService(IUserRepository userRepository, IUserTypeRepository userTypeRepository)
        {
            _userRepository = userRepository;
            _userTypeRepository = userTypeRepository;
        }

        public List<UserType> GetAllUserTypes()
        {
            return _userTypeRepository.GetAllAsQueryable().ToList();
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAllAsQueryable();
        }

        public User GetById(Guid id)
        {
            return _userRepository.FindById(id);
        }

        public void CreateUser(UserDto userDto)
        {
            _userRepository.Create(new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Username = userDto.Username,
                Password = userDto.Password,
                UserTypeId = userDto.UserType.Id
            });
            _userRepository.Save();
        }

        public void CreateUserType(UserType userType)
        {
            _userTypeRepository.Create(userType);
            _userTypeRepository.Save();
        }
    }
}
