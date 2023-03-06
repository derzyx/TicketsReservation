using Application.Exceptions;
using Application.IRepositories;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Payments.UpdatePayment
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, bool>
    {
        private readonly IPaymentRepository paymentRepository;

        public UpdatePaymentCommandHandler(IPaymentRepository _paymentRepository)
        {
            paymentRepository = _paymentRepository;
        }

        public async Task<bool> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await paymentRepository.GetByIdAsync(request.Id);

            if (payment == null) throw new PaymentNotFoundException();

            if (payment.Status == PaymentStatutes.Pending)
            {
                payment.ChangeStatus(request.Status);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
