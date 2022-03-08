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
            return user;
        }

        public async Task<User> GetByToken(Guid token)
        {
            var user = await _userDataService.GetByToken(token);
            return user;
        }

        public async Task<bool> AddPostToUser(User user, Post post)
        {
            if (user.CreatedPosts.Any(p => p.Title == post.Title))
            {
                return false;
            }
            user.CreatedPosts.Add(post);
            await _userDataService.Update(user.Id, user);
            return true;
        }
    }
}
