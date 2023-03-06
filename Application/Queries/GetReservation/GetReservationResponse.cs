using Domain.Entities;
using Domain.Enums;

namespace Application.Queries.GetReservation
{
    public record GetReservationResponse(Guid Id, ICollection<Ticket> products, ReservationStatutes status, DateTime paymentDeadline);
}