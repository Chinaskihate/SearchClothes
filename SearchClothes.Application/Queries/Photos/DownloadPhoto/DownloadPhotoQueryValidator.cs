using FluentValidation;
using System;

namespace SearchClothes.Application.Queries.Photos.DownloadPhoto
{
    public class DownloadPhotoQueryValidator : AbstractValidator<DownloadPhotoQuery>
    {
        public DownloadPhotoQueryValidator()
        {
            RuleFor(downloadPhotoQuery =>
                downloadPhotoQuery.Token).NotEqual(Guid.Empty);
            RuleFor(downloadPhotoQuery =>
                downloadPhotoQuery.PostId).NotEqual(Guid.Empty);
        }
    }
}
