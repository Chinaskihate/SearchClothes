using FluentValidation;
using System;

namespace SearchClothes.Application.Queries.Posts.GetUserPosts
{
    public class GetUserPostsQueryValidator : AbstractValidator<GetUserPostsQuery>
    {
        public GetUserPostsQueryValidator()
        {
            RuleFor(getUserPostsQuery =>
                getUserPostsQuery.Token).NotEqual(Guid.Empty);
        }
    }
}
