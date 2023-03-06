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

namespace Application.Commands.Payments.NewPayment
{
    public class NewPaymentCommandHandler : IRequestHandler<NewPaymentCommand, bool>
    {
        private readonly IPaymentRepository paymentRepository;

        public NewPaymentCommandHandler(IPaymentRepository _paymentRepository)
        {
            paymentRepository = _paymentRepository;
        }

        public async Task<bool> Handle(NewPaymentCommand request, CancellationToken cancellationToken)
        {
            if (request.Reservation == null) throw new ReservationNotFoundException();

            if(request.Reservation.Status == ReservationStatutes.PaymentPending)
            {
                if (request.Reservation.PaymentDeadline < DateTime.UtcNow)
                {
                    request.Reservation.Status = ReservationStatutes.Canceled;
                    request.Reservation.Archive();
                    return false;
                    // Can't pay anymore
                }

                decimal amount = 0;
                foreach (var ticket in request.Reservation.Products)
                {
                    amount += ticket.Price;
                }

                var payment = await paymentRepository.AddAsync(new Payment(amount, request.Methode, request.ReservationId, request.BuyerId));

                // Send request to payment system

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
