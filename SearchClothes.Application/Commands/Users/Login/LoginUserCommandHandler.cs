using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SearchClothes.Application.Common.Posts;
using SearchClothes.Application.Common.Users;
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
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserLookupDto>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public async Task<UserLookupDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _authenticationService.Login(request.Email, request.Password);
            var userDto = _mapper.Map<UserLookupDto>(user);
            return userDto;
        }
    }
}
