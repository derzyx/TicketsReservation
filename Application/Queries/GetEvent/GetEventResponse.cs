using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetEvent
{
    public record GetEventResponse(Guid Id, string Name, string Description, DateTime StartDate, DateTime EndDate, Location Location, int AllTickets);
}
