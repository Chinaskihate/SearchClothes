using MediatR;
using SearchClothes.Application.Queries.Posts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Queries.Posts.GetUserPosts
{
    public class GetUserPostsQuery : IRequest<PostListVm>
    {
        public Guid Token { get; set; }
    }
}
