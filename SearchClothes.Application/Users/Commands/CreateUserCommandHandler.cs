using MediatR;
using SearchClothes.Application.Interfaces;
using SearchClothes.Application.Interfaces.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IAuthenticationService _authenticationService;

        public CreateUserCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // TODO: change it
            //var user = await _authenticationService.Verificate(request.Username, request.Email,
            //    request.PasswordHash, request.VerificationCode);

            //return user is null ? Guid.Empty : user.Id;
            return Guid.Empty;
        }
    }
}
