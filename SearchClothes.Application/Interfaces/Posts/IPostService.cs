using SearchClothes.Application.Common.Tags;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchClothes.Application.Interfaces.Posts
{
    public enum CreatePostResult
    {
        Success,
        UserHavePostWithThisTitle,
        UserDoesNotExist,
        ServerError
    }

    public interface IPostService
    {
        public Task<Post> CreatePost((Guid CreatorId, 
            string Title,
            string Description, 
            string SellerLink,
            IEnumerable<TagLookupDto> Tags) postInfo);

        public Task<IEnumerable<Post>> GetPosts(string title, IEnumerable<TagLookupDto> tags, double minRate);

        public Task<IEnumerable<Post>> GetUserPosts(Guid userId);

        public Task<bool> RemovePost(Guid creatorId, Guid postId);

        public Task<Post> UpdatePost(Guid creatorId,
            (Guid PostId,
            string Title,
            string Description,
            string SellerLink,
            IEnumerable<TagLookupDto> Tags) newPostInfo);

        public Task<Post> GetPostById(Guid postId);

        public Task<IEnumerable<Post>> GetRatedPosts(Guid userId);
    }
}
