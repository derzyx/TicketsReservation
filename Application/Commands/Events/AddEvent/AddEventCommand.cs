using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Events.AddEvent
{
    public record AddEventCommand(string Name, string Description, DateTime StartDate, DateTime EndDate, Location Location, int AllTickets) : IRequest<Event>;
}
