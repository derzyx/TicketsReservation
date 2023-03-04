using Application.Exceptions;
using Application.Queries.GetEvent;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries.GetEvent
{
    public class GetEventHandler : IRequestHandler<GetEventQuery, GetEventResponse>
    {
        private readonly Context dbContext;
        private readonly DbSet<Event> events;

        public GetEventHandler(Context _dbContext)
        {
            dbContext = _dbContext;
            events = dbContext.Events;
        }

        public async Task<GetEventResponse> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            var ev = await events.Where(x => x.Id == request.Id)
                .Select(x => new GetEventResponse(x.Id, x.Name, x.Description, x.StartDate, x.EndDate, x.Location, x.AllTickets))
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (ev == null) throw new EventNotFoundException();

            return ev;
        }
    }
}
