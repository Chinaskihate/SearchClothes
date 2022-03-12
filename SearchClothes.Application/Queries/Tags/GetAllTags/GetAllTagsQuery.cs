using MediatR;
using SearchClothes.Application.Common.Tags;
using System;

namespace SearchClothes.Application.Queries.Tags.GetAllTags
{
    public class GetAllTagsQuery : IRequest<TagListVm>
    {
        public Guid Token { get; set; }
    }
}
