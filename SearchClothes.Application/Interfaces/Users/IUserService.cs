using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Interfaces.Users
{
    public interface IUserService
    {
        Task<User> GetByToken(Guid token);

        Task<User> GetById(Guid id);

        Task<bool> AddPostToUser(Guid userId, Post post);

        Task<bool> RemovePostFromUser(Guid userId, Guid postId);

        Task<bool> HavePostWithTitle(Guid userId, string title);
    }
}
