using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DAWProject.Helpers;
using DAWProject.Models.Base;
using DAWProject.Models.DTOs;
using DAWProject.Services.EmployeeService;
using DAWProject.Services.UserService;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DAWProject.Services.AuthenticationService
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IEmployeeService _employeeService;
        private readonly AppSettings _appSettings;

        public AuthenticationService(IUserService userService, IEmployeeService employeeService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _employeeService = employeeService;
            _appSettings = appSettings.Value;
        }

        public UserResponseDto AuthenticateUser(UserRequestDTO model)
        {
            var user = _userService.GetAll().SingleOrDefault(
                x => x.Username == model.Username && x.Password == model.Password);

            if (user == null) return null;

            var token = GenerateUserJwtToken(user);

            return new UserResponseDto(user, token);
        }

        public UserResponseDto AuthenticateEmployee(UserRequestDTO model)
        {
            var user = _employeeService.GetAll().SingleOrDefault(
                x => x.Username == model.Username && x.Password == model.Password);

            if (user == null) return null;

            var token = GenerateUserJwtToken(user);

            return new UserResponseDto(user, token);
        }

        private string GenerateUserJwtToken(IBaseEntity entity)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", entity.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
