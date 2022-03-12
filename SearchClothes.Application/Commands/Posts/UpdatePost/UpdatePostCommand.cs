using MediatR;
using SearchClothes.Application.Common.Posts;
using SearchClothes.Application.Common.Tags;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Posts.UpdatePost
{
    public class UpdatePostCommand : IRequest<PostLookupDto>
    {
        public Guid Token { get; set; }

        public Guid PostId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SellerLink { get; set; }

        public IEnumerable<TagLookupDto> Tags { get; set; }
    }
}
