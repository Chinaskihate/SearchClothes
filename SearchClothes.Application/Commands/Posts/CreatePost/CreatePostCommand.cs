using MediatR;
using SearchClothes.Application.Common.Posts;
using SearchClothes.Application.Common.Tags;
using System;
using System.Collections.Generic;

namespace SearchClothes.Application.Commands.Posts.CreatePost
{
    public class CreatePostCommand : IRequest<PostLookupDto>
    {
        public Guid Token { get; set; }

        public string Title { get; set; }
    
        public string Description { get; set; }

        public string SellerLink { get; set; }

        public IEnumerable<TagLookupDto> Tags { get; set; }
    }
}
