using AutoMapper;
using MediatR;
using SearchClothes.Application.Common.Users;
using SearchClothes.Application.Interfaces.Authentication;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Users.VerificateUser
{
    public class VerificateUserCommandHandler : IRequestHandler<VerificateUserCommand, UserLookupDto>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public VerificateUserCommandHandler(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public async Task<UserLookupDto> Handle(VerificateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _authenticationService.Verificate(request.Email, request.VerificationCode);
            if (user == null)
            {
                return null;
            }
            var userDto = _mapper.Map<UserLookupDto>(user);

            return userDto;
        }
    }
}
