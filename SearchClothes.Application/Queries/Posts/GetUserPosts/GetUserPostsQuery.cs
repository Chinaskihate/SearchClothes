using MediatR;
using SearchClothes.Application.Common.Posts;
using System;

namespace SearchClothes.Application.Queries.Posts.GetUserPosts
{
    public class GetUserPostsQuery : IRequest<PostListVm>
    {
        public Guid Token { get; set; }
    }
}
