using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Payments.UpdatePayment
{
    public record UpdatePaymentCommand(Guid Id, PaymentStatutes Status) : IRequest<bool>;

}
