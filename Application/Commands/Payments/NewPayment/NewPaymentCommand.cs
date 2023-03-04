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
    public record NewPaymentCommand(PaymentMethodes Methode, Reservation Reservation, User Buyer) : IRequest<bool>;
}
