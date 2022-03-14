using SearchClothes.Application.Common.Exceptions;
using SearchClothes.Application.Interfaces.DataServices;
using SearchClothes.Application.Interfaces.Users;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Services.Users
{
    public class UserService : IUserService
    {
        private IUserDataService _userDataService;

        public UserService(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }

        public async Task<User> GetById(Guid id)
        {
            var user = await _userDataService.Get(id);
            if (user == null)
            {
                throw new UserNotFoundException(string.Empty, id, Guid.Empty);
            }
            return user;
        }

        public async Task<User> GetByToken(Guid token)
        {
            var user = await _userDataService.GetByToken(token);
            if (user == null)
            {
                throw new UserNotFoundException(string.Empty, Guid.Empty, token);
            }
            return user;
        }

        public async Task<bool> AddPostToUser(Guid userId, Post post)
        {
            var user = await _userDataService.Get(userId);
            if (user == null)
            {
                throw new UserNotFoundException(string.Empty, userId, Guid.Empty);
            }
            if (await HavePostWithTitle(userId, post.Title))
            {
                return false;
            }
            user.CreatedPosts.Add(post);
            await _userDataService.Update(user.Id, user);
            return true;
        }

        public async Task<bool> HavePostWithTitle(Guid userId, string title)
        {
            var user = await _userDataService.Get(userId);
            if (user == null)
            {
                throw new UserNotFoundException(string.Empty, userId, Guid.Empty);
            }
            return user.CreatedPosts.Any(p => p.Title == title);
        }

        public async Task<bool> RemovePostFromUser(Guid userId, Guid postId)
        {
            var user = await _userDataService.Get(userId);
            if (user == null)
            {
                throw new UserNotFoundException(string.Empty, userId, Guid.Empty);
            }
            var removedPost = user.CreatedPosts.FirstOrDefault(p => p.Id == postId);
            if (removedPost == null)
            {
                return false;
            }
            user.CreatedPosts.Remove(removedPost);
            await _userDataService.Update(user.Id, user);
            return true;
        }
    }
}
