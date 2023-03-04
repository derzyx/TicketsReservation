using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Reservations.AddReservation
{
    public record AddReservationCommand(ICollection<Ticket> Products) : IRequest<Reservation>;
}
