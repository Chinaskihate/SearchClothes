using FluentValidation;
using System;
using System.Linq;

namespace SearchClothes.Application.Commands.Posts.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(createPostCommand =>
                createPostCommand.Token).NotEqual(Guid.Empty);
            RuleFor(createPostCommand =>
                createPostCommand.Title).NotEmpty().MaximumLength(255);
            RuleFor(createPostCommand =>
                createPostCommand.SellerLink).NotEmpty();
            RuleFor(createPostCommand =>
                createPostCommand.Description).MaximumLength(300);
            RuleFor(createPostCommand =>
                createPostCommand.Tags).Must(tags => tags.Count() < 20);
        }
    }
}
