using Application.IRepositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {
        private readonly IUserRepository userRepository;

        public AddUserCommandHandler(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.AddAsync(new User(request.Nickname, request.Password));

            return await Task.FromResult(user);
        }
    }
}
