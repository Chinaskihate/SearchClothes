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
            IEnumerable<Tag> Tags) postInfo);

        public Task<IEnumerable<Post>> GetPosts(string title, IEnumerable<Tag> tags, double minRate);

        public Task<IEnumerable<Post>> GetUserPosts(Guid userId);

        public Task<bool> RemovePost(Guid postId);

        public Task<Post> UpdatePost((Guid PostId,
            string Title,
            string Description,
            string SellerLink,
            IEnumerable<Tag> Tags) newPostInfo);
    }
}
