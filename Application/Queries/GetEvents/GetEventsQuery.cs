using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetEvents
{
    public record GetEventsQuery() : IRequest<GetEventsResponse>;
}
