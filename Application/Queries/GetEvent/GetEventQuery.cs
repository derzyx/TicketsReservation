using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetEvent
{
    public record GetEventQuery(Guid Id) : IRequest<GetEventResponse>;
}
