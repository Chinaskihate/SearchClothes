using SearchClothes.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SearchClothes.Application.Interfaces.Users
{
    public interface IUserService
    {
        Task<User> GetByToken(Guid token);

        Task<User> GetById(Guid id);

        Task<bool> AddCreatedPostToUser(Guid userId, Post post);

        Task<bool> AddRatedPostToUser(Guid userId, Post post);

        Task<bool> RemovePostFromUser(Guid userId, Guid postId);

        Task<bool> HavePostWithTitle(Guid userId, string title);
    }
}
