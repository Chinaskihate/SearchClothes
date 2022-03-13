using FluentValidation;

namespace SearchClothes.Application.Commands.Users.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(createUserCommand =>
               createUserCommand.Email).NotEmpty().MaximumLength(255);
            RuleFor(createUserCommand =>
               createUserCommand.Username).NotEmpty().MaximumLength(255);
            RuleFor(createUserCommand =>
               createUserCommand.Password).NotEmpty().MaximumLength(255);
        }
    }
}
