using Abstractions.DTOs;
using Application.Queries.GetReservation;
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
    public record NewPaymentCommand(PaymentMethodes Methode, Guid ReservationId, Reservation Reservation, Guid BuyerId) : IRequest<bool>;
}
