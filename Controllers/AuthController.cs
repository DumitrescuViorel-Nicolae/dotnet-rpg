using dotnet_rpg.Data.DataModels;
using dotnet_rpg.Data.Interfaces;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace dotnet_rpg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(UserRegistrationDTO request)
        {
            await _authRepository.Register(new Models.User { Username = request.Username}, request.Password);
            return Ok("User created!");
        }
    }
}
