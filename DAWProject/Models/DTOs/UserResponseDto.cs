using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAWProject.Models.DTOs
{
    public class UserResponseDto
    {
        private Guid Id { get; }
        private string FirstName { get; }
        private string LastName { get; }

        private string Username { get; }
        private string Token { get; }

        public UserResponseDto(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Token = token;
        }
        
        public UserResponseDto(Employee employee, string token)
        {
            Id = employee.Id;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Username = employee.Username;
            Token = token;
        }
    }
}
