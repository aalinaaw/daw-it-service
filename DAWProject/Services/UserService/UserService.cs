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
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DAWProject.Services.UserService
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
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
                Password = userDto.Password
            });
            _userRepository.Save();
        }
    }
}
