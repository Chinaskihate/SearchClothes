using MediatR;
using SearchClothes.Application.Interfaces.Authentication;

namespace SearchClothes.Application.Commands.Users.CreateUser
{
    public class CreateUserCommand : IRequest<RegistrationResult>
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
