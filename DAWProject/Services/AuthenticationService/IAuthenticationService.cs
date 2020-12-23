using DAWProject.Models.DTOs;

namespace DAWProject.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        public UserResponseDto AuthenticateUser(UserRequestDTO model);
        public UserResponseDto AuthenticateEmployee(UserRequestDTO model);
    }
}
