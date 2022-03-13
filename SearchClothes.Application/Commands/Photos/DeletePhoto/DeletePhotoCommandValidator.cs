using FluentValidation;
using System;

namespace SearchClothes.Application.Commands.Photos.DeletePhoto
{
    public class DeletePhotoCommandValidator : AbstractValidator<DeletePhotoCommand>
    {
        public DeletePhotoCommandValidator()
        {
            RuleFor(savePhotoCommand =>
                savePhotoCommand.Token).NotEqual(Guid.Empty);
            RuleFor(savePhotoCommand =>
                savePhotoCommand.PostId).NotEqual(Guid.Empty);
        }
    }
}
