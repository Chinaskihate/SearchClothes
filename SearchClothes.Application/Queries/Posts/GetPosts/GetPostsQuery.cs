using MediatR;
using SearchClothes.Application.Common.Posts;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;

namespace SearchClothes.Application.Queries.Posts.GetPosts
{
    public class GetPostsQuery : IRequest<PostListVm>
    {
        public Guid Token { get; set; }

        public string Title { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public double MinimumRate { get; set; }
    }
}
