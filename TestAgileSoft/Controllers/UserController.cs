using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestAgileSoft.Application.User.Commands;
using TestAgileSoft.Application.User.Query;
using TestAgileSoft.Domain.Dtos;

namespace TestAgileSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<UserDto> GetUser() => await _mediator.Send(new GetUserQuery());

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<UserDto> LoginAsync(UserLoginCommand userLoginCommand) => await _mediator.Send(userLoginCommand);

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<UserDto> RegisterAsync(UserRegisterCommand userRegisterCommand) => await _mediator.Send(userRegisterCommand);
    }
}
