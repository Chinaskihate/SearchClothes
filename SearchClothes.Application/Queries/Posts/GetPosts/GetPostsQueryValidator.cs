using FluentValidation;
using System;

namespace SearchClothes.Application.Queries.Posts.GetPosts
{
    public class GetPostsQueryValidator : AbstractValidator<GetPostsQuery>
    {
        public GetPostsQueryValidator()
        {
            RuleFor(getPostsQuery =>
                getPostsQuery.Token).NotEqual(Guid.Empty);
        }
    }
}
