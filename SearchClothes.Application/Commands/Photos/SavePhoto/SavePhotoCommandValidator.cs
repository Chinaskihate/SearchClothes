using FluentValidation;
using System;

namespace SearchClothes.Application.Commands.Photos.SavePhoto
{
    public class SavePhotoCommandValidator : AbstractValidator<SavePhotoCommand>
    {
        public SavePhotoCommandValidator()
        {
            RuleFor(savePhotoCommand =>
                savePhotoCommand.Token).NotEqual(Guid.Empty);
            RuleFor(savePhotoCommand =>
                savePhotoCommand.PostId).NotEqual(Guid.Empty);
            RuleFor(savePhotoCommand =>
                savePhotoCommand.Photo).NotNull().Must(photo => photo.Length < 5e+7);
        }
    }
}
