using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestAgileSoft.Application.User.Dtos;
using TestAgileSoft.Application.User.Query;

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
    }
}
