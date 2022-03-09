using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Queries.Posts.Common
{
    public class PostListVm
    {
        public IList<PostLookupDto> Posts { get; set; }
    }
}
