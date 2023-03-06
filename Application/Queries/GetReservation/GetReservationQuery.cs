using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetReservation
{
    public record GetReservationQuery(Guid Id) : IRequest<GetReservationResponse>;
}
