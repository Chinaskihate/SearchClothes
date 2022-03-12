using MediatR;
using SearchClothes.Application.Common.Posts;
using SearchClothes.Application.Common.Tags;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;

namespace SearchClothes.Application.Queries.Posts.GetPosts
{
    public class GetPostsQuery : IRequest<PostListVm>
    {
        public Guid Token { get; set; }

        public string Title { get; set; }

        public IEnumerable<TagLookupDto> Tags { get; set; }

        public double MinimumRate { get; set; }
    }
}
