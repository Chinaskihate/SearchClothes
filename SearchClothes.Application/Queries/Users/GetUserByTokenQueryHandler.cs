using MediatR;
using SearchClothes.Application.Interfaces.Authentication;
using SearchClothes.Application.Interfaces.Users;
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
        private readonly IUserService _userService;

        public GetUserByTokenQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Handle(GetUserByTokenQuery request, CancellationToken cancellationToken)
        {
            var result = await _userService.GetByToken(request.Token);
            return result;
        }
    }
}
