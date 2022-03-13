using FluentValidation;
using System;

namespace SearchClothes.Application.Queries.Tags.GetTagsByName
{
    public class GetTagsByNameQueryValidator : AbstractValidator<GetTagsByNameQuery>
    {
        public GetTagsByNameQueryValidator()
        {
            RuleFor(getPostsQuery =>
                getPostsQuery.Token).NotEqual(Guid.Empty);
        }
    }
}
