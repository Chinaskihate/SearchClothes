using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Queries.Posts.GetPosts
{
    public class PostListVm
    {
        public IList<PostLookupDto> Posts { get; set; }
    }
}
