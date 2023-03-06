using Application.Queries.GetEvent;
using Application.Queries.GetEvents;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries.GetEvents
{
    public class GetEventsHandler : IRequestHandler<GetEventsQuery, GetEventsResponse>
    {
        private readonly Context dbContext;
        private readonly DbSet<Event> events;

        public GetEventsHandler(Context _dbContext)
        {
            dbContext = _dbContext;
            events = dbContext.Events;
        }

        public async Task<GetEventsResponse> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            var evs = await events
                .Select(x => new GetEventResponse(x.Id, x.Name, x.Description, x.StartDate, x.EndDate, x.Location, x.AllTickets))
                .Where(x => x.StartDate < DateTime.UtcNow)
                .ToListAsync(cancellationToken: cancellationToken);

            return new GetEventsResponse(evs);
        }
    }
}
