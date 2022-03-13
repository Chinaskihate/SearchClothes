using FluentValidation;

namespace SearchClothes.Application.Commands.Users.Login
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(loginUserCommand =>
               loginUserCommand.Email).NotEmpty().MaximumLength(255);
            RuleFor(loginUserCommand =>
               loginUserCommand.Password).NotEmpty().MaximumLength(255);
        }
    }
}
