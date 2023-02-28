using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Events.UpdateEvent
{
    public record UpdateEventCommand(Event ev) : IRequest<Event>;
}
