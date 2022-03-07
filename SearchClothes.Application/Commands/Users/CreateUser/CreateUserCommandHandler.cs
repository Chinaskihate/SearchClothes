using MediatR;
using SearchClothes.Application.Interfaces;
using SearchClothes.Application.Interfaces.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, RegistrationResult>
    {
        private readonly IAuthenticationService _authenticationService;

        public CreateUserCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<RegistrationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.Registration(request.Username, request.Email, request.Password);

            return result;
        }
    }
}
