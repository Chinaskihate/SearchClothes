using FluentValidation;
using System;

namespace SearchClothes.Application.Commands.Tags.CreateTag
{
    public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
    {
        public CreateTagCommandValidator()
        {
            RuleFor(createTagCommand =>
                createTagCommand.Token).NotEqual(Guid.Empty);
            RuleFor(createTagCommand =>
                createTagCommand.Name).NotEmpty().MaximumLength(255);
        }
    }
}
