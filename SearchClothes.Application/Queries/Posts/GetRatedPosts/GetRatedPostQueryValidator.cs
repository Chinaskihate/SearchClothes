using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Queries.Posts.GetRatedPosts
{
    public class GetRatedPostQueryValidator : AbstractValidator<GetRatedPostsQuery>
    {
        public GetRatedPostQueryValidator()
        {
            RuleFor(getUserPostsQuery =>
                getUserPostsQuery.Token).NotEqual(Guid.Empty);
        }
    }
}
