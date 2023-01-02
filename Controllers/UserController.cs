using AutoMapper;
using FlightREST.DataTransfer;
using FlightREST.Models;
using FlightREST.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FlightREST.Controllers
{
    public class UserController : ControllerBase
    {
        public readonly IGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserController(IGenericRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost("createUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(UserReadTransfer))]
        public async Task<IActionResult> CreatePlane([FromBody] UserBaseTransfer userDto)
        {
            var userModel = _mapper.Map<User>(userDto);

            var addedUser = await _userRepository.AddAsync(userModel);
            return Ok(_mapper.Map<UserReadTransfer>(addedUser));
        }

        [HttpPut("updateUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(UserReadTransfer))]
        public async Task<IActionResult> UpdatePlane([Required] long userId, [FromBody] UserBaseTransfer userDto)
        {
            var userModel = _mapper.Map<User>(userDto);
            userModel.Id = userId;

            var updatedPlane = await _userRepository.UpdateAsync(userModel);

            return Ok(_mapper.Map<UserReadTransfer>(updatedPlane));
        }
    }
}
