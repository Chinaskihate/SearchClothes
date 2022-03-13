using MediatR;
using SearchClothes.Application.Common.Posts;
using SearchClothes.Application.Common.Tags;
using System;
using System.Collections.Generic;

namespace SearchClothes.Application.Commands.Posts.UpdatePost
{
    public class UpdatePostCommand : TokenizedCommand, IRequest<PostLookupDto>
    {
        public Guid PostId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SellerLink { get; set; }

        public IEnumerable<TagLookupDto> Tags { get; set; }
    }
}
