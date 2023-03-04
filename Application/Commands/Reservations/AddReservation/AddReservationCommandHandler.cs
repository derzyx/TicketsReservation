using Application.Exceptions;
using Application.IRepositories;
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
    public class AddReservationCommandHandler : IRequestHandler<AddReservationCommand, Reservation>
    {
        private readonly IReservationRepository reservationRepository;

        public AddReservationCommandHandler(IReservationRepository _reservationRepository)
        {
            reservationRepository = _reservationRepository;
        }

        public async Task<Reservation> Handle(AddReservationCommand request, CancellationToken cancellationToken)
        {
            if (!request.Products.Any())
            {
                throw new EmptyReservationException();
            }

            var status = ReservationStatutes.PaymentPending;
            var paymentDeadline = DateTime.UtcNow.AddDays(7);

            var reservation = await reservationRepository.AddAsync(new Reservation(request.Products, status, paymentDeadline));

            return await Task.FromResult(reservation);
        }
    }
}
