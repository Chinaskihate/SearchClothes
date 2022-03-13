using FluentValidation;
using System;

namespace SearchClothes.Application.Commands.Posts.UpdatePost
{
    public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostCommandValidator()
        {
            RuleFor(updatePostCommand =>
               updatePostCommand.Token).NotEqual(Guid.Empty);
            RuleFor(updatePostCommand =>
                updatePostCommand.PostId).NotEqual(Guid.Empty);
            RuleFor(updatePostCommand =>
                updatePostCommand.Title).NotEmpty().MaximumLength(255);
            RuleFor(updatePostCommand =>
                updatePostCommand.SellerLink).NotEmpty();
            RuleFor(updatePostCommand =>
                updatePostCommand.Description).MaximumLength(300);
        }
    }
}
