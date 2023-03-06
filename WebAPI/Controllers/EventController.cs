using Application.Commands.Events.AddEvent;
using Application.Queries.GetEvents;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator mediator;

        public EventController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] GetEventsQuery query)
        {
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromQuery] AddEventCommand ev)
        {
            var response = await mediator.Send(ev);
            return Ok(response);
        }
    }
}
