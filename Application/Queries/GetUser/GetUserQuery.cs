﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetUser
{
    public record GetUserQuery(Guid Id) : IRequest<GetUserResponse>;
}
