using MediatR;
using SearchClothes.Application.Interfaces.Authentication;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Queries.Users
{
    public class GetUserByTokenQueryHandler : IRequestHandler<GetUserByTokenQuery, User>
    {
        private readonly IAuthenticationService _authenticationService;

        public GetUserByTokenQueryHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<User> Handle(GetUserByTokenQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.GetByToken(request.Token);
            return result;
        }
    }
}
