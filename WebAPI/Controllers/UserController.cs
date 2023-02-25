using Application.Commands.AddUser;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromQuery] AddUserCommand user)
        {
            var response = await mediator.Send(user);
            return Ok(response);
        }
    }
}
