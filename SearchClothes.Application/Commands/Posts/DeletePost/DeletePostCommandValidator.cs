using FluentValidation;
using System;

namespace SearchClothes.Application.Commands.Posts.DeletePost
{
    public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
    {
        public DeletePostCommandValidator()
        {
            RuleFor(deletePostCommand =>
                deletePostCommand.Token).NotEqual(Guid.Empty);
            RuleFor(deletePostCommand =>
                deletePostCommand.PostId).NotEqual(Guid.Empty);
        }
    }
}
