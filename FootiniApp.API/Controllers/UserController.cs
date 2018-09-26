using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FootiniApp.API.Data;
using FootiniApp.API.Dtos;
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
        public IMapper _Mapper { get; }

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _UserRepository = userRepository;
            _Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {

            var users = await _UserRepository.GetUsers();

            var userToReturn = _Mapper.Map<IEnumerable<UserForList>>(users);

            return Ok(userToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _UserRepository.GetUser(id);
            var userToReturn = _Mapper.Map<UserForList>(user);
            return Ok(userToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, userForUpdateDto userForUpdateDto) {

            if(id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            return Unauthorized();

            var userFromRepo = await _UserRepository.GetUser(id);
            _Mapper.Map(userForUpdateDto, userFromRepo);
            if (await _UserRepository.SaveAll())
            return NoContent();

            throw new Exception($"Updating user {id} failed on server");

        }
    }
}