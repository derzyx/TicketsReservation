using Application.Exceptions;
using Application.IRepositories;
using Application.Queries.GetUser;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries.GetUser
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, GetUserResponse>
    {
        private readonly Context dbContext;
        private readonly DbSet<User> users;

        public GetUserHandler(Context _dbContext)
        {
            dbContext = _dbContext;
            users = dbContext.Users;
        }

        public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await users.Where(x => x.Id == request.Id)
                .Select(x => new GetUserResponse(x.Id, x.Username))
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (user == null) throw new UserNotFoundException();

            return user;
        }
    }
}
