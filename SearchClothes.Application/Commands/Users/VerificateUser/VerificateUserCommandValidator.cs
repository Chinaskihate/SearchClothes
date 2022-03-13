using FluentValidation;
using System;

namespace SearchClothes.Application.Commands.Users.VerificateUser
{
    public class VerificateUserCommandValidator : AbstractValidator<VerificateUserCommand>
    {
        public VerificateUserCommandValidator()
        {
            RuleFor(verificateUserCommand =>
                verificateUserCommand.Email).NotEmpty().MaximumLength(255);
            RuleFor(verificateUserCommand =>
                verificateUserCommand.VerificationCode).NotEqual(Guid.Empty);
        }
    }
}
