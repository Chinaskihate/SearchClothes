using MediatR;
using SearchClothes.Application.Queries.Posts.Common;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
