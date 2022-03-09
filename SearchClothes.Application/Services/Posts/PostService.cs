using Microsoft.AspNetCore.Http;
using SearchClothes.Application.Interfaces.Authentication;
using SearchClothes.Application.Interfaces.DataServices;
using SearchClothes.Application.Interfaces.Photos;
using SearchClothes.Application.Interfaces.Posts;
using SearchClothes.Application.Interfaces.Users;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly IPostDataService _postDataService;
        private readonly IUserService _userService;

        public PostService(IPostDataService postDataService, IUserService userService)
        {
            _postDataService = postDataService;
            _userService = userService;
        }

        public async Task<Post> CreatePost((Guid CreatorId, 
            string Title, 
            string Description, 
            string SellerLink,
            IEnumerable<Tag> Tags) postInfo)
        {
            var user = await _userService.GetById(postInfo.CreatorId);

            var newPost = new Post()
            {
                Id = Guid.NewGuid(),
                CreatorId = postInfo.CreatorId,
                Title = postInfo.Title,
                Description = postInfo.Description,
                SellerLink = postInfo.SellerLink,
                Tags = postInfo.Tags.ToList(),
                Rates = new List<Rate>(),
                CreationTime = DateTime.Now,
                LastEditTime = DateTime.Now
            };

            // TODO: check if user already have it in this method.
            await _postDataService.Create(newPost);
            var isCreated = await _userService.AddPostToUser(user, newPost);
            if(!isCreated)
            {
                return null;
            }
            return newPost;
        }

        public async Task<IEnumerable<Post>> GetPosts(string title, IEnumerable<Tag> tags, double minRate)
        {
            var posts = await _postDataService.GetPosts(title, tags, minRate);
            return posts;
        }
    }
}
