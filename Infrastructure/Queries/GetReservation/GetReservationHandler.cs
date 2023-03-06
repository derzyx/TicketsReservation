using Application.Exceptions;
using Application.Queries.GetReservation;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries.GetReservation
{
    public class GetReservationHandler : IRequestHandler<GetReservationQuery, GetReservationResponse>
    {
        private readonly Context dbContext;
        private readonly DbSet<Reservation> reservations;

        public GetReservationHandler(Context _dbContext)
        {
            dbContext = _dbContext;
            reservations = dbContext.Reservations;
        }

        public async Task<GetReservationResponse> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var reservation = await reservations.Where(x => x.Id == request.Id)
                .Select(x => new GetReservationResponse(x.Id, x.Products, x.Status, x.PaymentDeadline))
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (reservation == null) throw new ReservationNotFoundException();

            return reservation;
        }
    }
}
