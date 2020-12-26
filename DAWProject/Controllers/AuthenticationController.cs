using DAWProject.Models.DTOs;
using DAWProject.Services.AuthenticationService;
using Microsoft.AspNetCore.Mvc;

namespace DAWProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticateUser")]
        public IActionResult AuthenticateUser(UserRequestDTO user)
        {
            var result = _authenticationService.AuthenticateUser(user);

            if(result == null)
            {
                return Unauthorized(new { Message = "Username or Password is invalid!" });
            }
            return Ok(result);
        }
        
        [HttpPost("authenticateEmployee")]
        public IActionResult AuthenticateEmployee(UserRequestDTO user)
        {
            var result = _authenticationService.AuthenticateEmployee(user);

            if(result == null)
            {
                return Unauthorized(new { Message = "Username or Password is invalid!" });
            }
            return Ok(result);
        }
    }
}
