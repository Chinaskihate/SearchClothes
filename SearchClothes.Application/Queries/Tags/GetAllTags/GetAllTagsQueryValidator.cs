using FluentValidation;
using System;

namespace SearchClothes.Application.Queries.Tags.GetAllTags
{
    public class GetAllTagsQueryValidator : AbstractValidator<GetAllTagsQuery>
    {
        public GetAllTagsQueryValidator()
        {
            RuleFor(getAllTagsQuery =>
                getAllTagsQuery.Token).NotEqual(Guid.Empty);
        }
    }
}
