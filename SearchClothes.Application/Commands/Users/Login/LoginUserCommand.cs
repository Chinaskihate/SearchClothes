using MediatR;
using SearchClothes.Application.Common.Users;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Users.Login
{
    public class LoginUserCommand : IRequest<UserLookupDto>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
