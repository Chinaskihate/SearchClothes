using MediatR;
using SearchClothes.Application.Interfaces.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Users.CreateUser
{
    public class CreateUserCommand : IRequest<RegistrationResult>
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
