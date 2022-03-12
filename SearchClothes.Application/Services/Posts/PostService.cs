using AutoMapper;
using SearchClothes.Application.Common.Tags;
using SearchClothes.Application.Interfaces.DataServices;
using SearchClothes.Application.Interfaces.Posts;
using SearchClothes.Application.Interfaces.Tags;
using SearchClothes.Application.Interfaces.Users;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchClothes.Application.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly IPostDataService _postDataService;
        private readonly IUserService _userService;
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public PostService(IPostDataService postDataService, IUserService userService, ITagService tagService, IMapper mapper)
        {
            _postDataService = postDataService;
            _userService = userService;
            _tagService = tagService;
            _mapper = mapper;
        }

        public async Task<Post> CreatePost((Guid CreatorId,
            string Title,
            string Description,
            string SellerLink,
            IEnumerable<TagLookupDto> Tags) postInfo)
        {
            var user = await _userService.GetById(postInfo.CreatorId);
            bool flag = !postInfo.Tags.Any() || await _tagService.Exists(postInfo.Tags);
            if (!flag)
            {
                return null;
            }
            var newPost = new Post()
            {
                Id = Guid.NewGuid(),
                CreatorId = postInfo.CreatorId,
                Title = postInfo.Title,
                Description = postInfo.Description,
                SellerLink = postInfo.SellerLink,
                Tags = (await _tagService.ConvertDtoToTags(postInfo.Tags)).ToList(),
                Rates = new List<Rate>(),
                CreationTime = DateTime.Now,
                LastEditTime = DateTime.Now
            };
            foreach (var tag in newPost.Tags)
            {
                tag.Posts.Add(newPost);
            }
            if (await _userService.HavePostWithTitle(newPost.CreatorId, newPost.Title))
            {
                return null;
            }
            newPost = await _postDataService.Create(newPost);
            var isCreated = await _userService.AddPostToUser(user.Id, newPost);
            if (!isCreated)
            {
                return null;
            }
            return newPost;
        }

        public async Task<Post> GetPostById(Guid postId)
        {
            var post = await _postDataService.Get(postId);
            return post;
        }

        public async Task<IEnumerable<Post>> GetPosts(string title, IEnumerable<TagLookupDto> tagsDto, double minRate)
        {
            var tags = await _tagService.ConvertDtoToTags(tagsDto);
            var posts = await _postDataService.GetPosts(title, tags, minRate);
            return posts;
        }

        public async Task<IEnumerable<Post>> GetUserPosts(Guid userId)
        {
            var posts = await _postDataService.GetByCreatorId(userId);
            return posts;
        }

        public async Task<bool> RemovePost(Guid postId)
        {
            var post = await _postDataService.Get(postId);
            if (post == null)
            {
                return false;
            }
            //var result = await _userService.RemovePostFromUser(post.CreatorId, postId);
            //if (result)
            //{
            //    await _postDataService.Delete(postId);
            //}
            await _postDataService.Delete(postId);
            return true;

        }

        public async Task<Post> UpdatePost((Guid PostId,
            string Title,
            string Description,
            string SellerLink,
            IEnumerable<TagLookupDto> Tags) newPostInfo)
        {
            var post = await _postDataService.Get(newPostInfo.PostId);
            if (post == null)
            {
                return null;
            }

            bool flag = !newPostInfo.Tags.Any() || await _tagService.Exists(newPostInfo.Tags);
            if (!flag)
            {
                return null;
            }

            post.Title = newPostInfo.Title;
            post.Description = newPostInfo.Description;
            post.SellerLink = newPostInfo.SellerLink;
            post.LastEditTime = DateTime.Now;
            post.Tags = (await _tagService.ConvertDtoToTags(newPostInfo.Tags)).ToList();
            foreach (var tag in post.Tags)
            {
                tag.Posts.Add(post);
            }

            var newPost = await _postDataService.Update(post.Id, post);
            return newPost;
        }
    }
}
