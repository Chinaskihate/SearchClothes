using MediatR;
using Microsoft.AspNetCore.Http;
using SearchClothes.Application.Interfaces.Posts;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Posts.CreatePost
{
    public class CreatePostCommand : IRequest<Post>
    {
        public Guid Token { get; set; }

        public string Title { get; set; }
    
        public string Description { get; set; }

        public string SellerLink { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}
