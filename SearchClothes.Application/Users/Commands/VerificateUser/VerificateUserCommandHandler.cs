using MediatR;
using SearchClothes.Application.Interfaces.Authentication;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Users.Commands.VerificateUser
{
    public class VerificateUserCommandHandler : IRequestHandler<VerificateUserCommand, User>
    {
        private readonly IAuthenticationService _authenticationService;

        public VerificateUserCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<User> Handle(VerificateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _authenticationService.Verificate(request.Email, request.VerificationCode);

            return user;
        }
    }
}
