using MediatR;
using SearchClothes.Application.Interfaces.Authentication;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Users.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, User>
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginUserCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<User> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _authenticationService.Login(request.Email, request.Password);
            return user;
        }
    }
}
