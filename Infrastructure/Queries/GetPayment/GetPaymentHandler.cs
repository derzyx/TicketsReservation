using Application.Exceptions;
using Application.Queries.GetPayment;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries.GetPayment
{
    public class GetPaymentHandler : IRequestHandler<GetPaymentQuery, GetPaymentResponse>
    {
        private readonly Context dbContext;
        private readonly DbSet<Payment> payments;

        public GetPaymentHandler(Context _dbContext)
        {
            dbContext = _dbContext;
            payments = dbContext.Payments;
        }

        public async Task<GetPaymentResponse> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            var payment = await payments
                .Where(x => x.Id == request.Id)
                .Select(x => new GetPaymentResponse(x.Id, x.Amount, x.Method, x.Status, x.ReservationId, x.BuyerId))
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (payment == null) throw new PaymentNotFoundException();

            return payment;
        }
    }
}
