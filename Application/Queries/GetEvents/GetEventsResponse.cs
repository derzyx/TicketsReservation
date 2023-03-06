using Application.Queries.GetEvent;
using Domain.Entities;

namespace Application.Queries.GetEvents
{
    public record GetEventsResponse(ICollection<GetEventResponse> Events);
}