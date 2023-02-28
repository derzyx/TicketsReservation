using Application.IRepositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Events.AddEvent
{
    public class AddEventCommandHandler : IRequestHandler<AddEventCommand, Event>
    {
        private readonly IEventRepository eventRepository;

        public AddEventCommandHandler(IEventRepository _eventRepository)
        {
            eventRepository = _eventRepository;
        }

        public async Task<Event> Handle(AddEventCommand request, CancellationToken cancellationToken)
        {
            var ev = await eventRepository.AddAsync(new Event(request.Name, request.Description, request.StartDate, request.EndDate, request.Location, request.AllTickets));

            return await Task.FromResult(ev);
        }
    }
}
