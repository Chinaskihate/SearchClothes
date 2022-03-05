using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SearchClothes.Application.Interfaces.Authentication;
using SearchClothes.Application.Users.Commands.CreateUser;
using SearchClothes.Application.Users.Commands.Login;
using SearchClothes.Application.Users.Commands.VerificateUser;
using SearchClothes.Domain.Models;
using SearchClothes.WebApi.Models;
using System;
using System.Threading.Tasks;

namespace SearchClothes.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost("/register")]
        public async Task<ActionResult<RegistrationResult>> Create([FromBody] CreateUserDto createUserDto)
        {
            var command = _mapper.Map<CreateUserCommand>(createUserDto);
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("/verificate")]
        // TODO: change return type
        public async Task<ActionResult<User>> Verificate([FromBody] VerificateUserDto verificateUserDto)
        {
            var command = _mapper.Map<VerificateUserCommand>(verificateUserDto);
            var user = await Mediator.Send(command);
            return Ok(user);
        }

        [HttpPost("/login")]
        public async Task<ActionResult<Guid>> Login([FromBody] LoginUserDto loginUserDto)
        {
            var command = _mapper.Map<LoginUserCommand>(loginUserDto);
            var user = await Mediator.Send(command);
            return Ok(user);
        }
    }
}
