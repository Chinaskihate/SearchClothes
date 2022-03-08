using MediatR;
using SearchClothes.Application.Interfaces.Authentication;
using SearchClothes.Application.Interfaces.Posts;
using SearchClothes.Application.Interfaces.Tags;
using SearchClothes.Application.Interfaces.Users;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Posts.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Post>
    {
        private IPostService _postService;
        private IUserService _userService;

        public CreatePostCommandHandler(IPostService postService, IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        public async Task<Post> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByToken(request.Token);
            if (user == null)
            {
                return null;
            }
            var result = await _postService.CreatePost((
                    user.Id,
                    request.Title,
                    request.Description,
                    request.SellerLink,
                    request.Tags
                ));
            return result;
        }
    }
}
