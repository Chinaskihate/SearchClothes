using MediatR;
using SearchClothes.Application.Common.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Queries.Posts.GetRatedPosts
{
    public class GetRatedPostsQuery : IRequest<PostListVm>
    {
        public Guid Token { get; set; }
    }
}
