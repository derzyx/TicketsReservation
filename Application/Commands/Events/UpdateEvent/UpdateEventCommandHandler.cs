using Application.IRepositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Events.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Event>
    {
        private readonly IEventRepository eventRepository;

        public UpdateEventCommandHandler(IEventRepository _eventRepository)
        {
            eventRepository = _eventRepository;
        }

        public async Task<Event> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var ev = await eventRepository.GetByIdAsync(request.ev.Id);

            ev = request.ev;

            return ev;
        }
    }
}
