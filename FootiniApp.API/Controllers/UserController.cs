using System.Threading.Tasks;
using FootiniApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FootiniApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [EnableCors("AllowAllHeaders")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserRepository _UserRepository { get; }
        public UserController(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {

            var users = await _UserRepository.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _UserRepository.GetUser(id);
            return Ok(user);
        }

    }
}