using AutoMapper;
using MediatR;
using SearchClothes.Application.Common.Posts;
using SearchClothes.Application.Interfaces.Posts;
using SearchClothes.Application.Interfaces.Users;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Posts.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, PostLookupDto>
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IPostService postService, IUserService userService,
            IMapper mapper)
        {
            _postService = postService;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<PostLookupDto> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByToken(request.Token);
            if (user == null) { return null; }
            var oldPost = user.CreatedPosts.FirstOrDefault(p => p.Id == request.PostId);
            var postWithNewTitle = user.CreatedPosts.FirstOrDefault(p => p.Title == request.Title);
            if (oldPost == null || (postWithNewTitle != null && oldPost.Id != postWithNewTitle.Id))
            {
                return null;
            }

            var newPost = await _postService.UpdatePost((request.PostId,
                request.Title,
                request.Description,
                request.SellerLink,
                request.Tags));
            if (newPost == null)
            {
                return null;
            }
            return _mapper.Map<PostLookupDto>(newPost);
        }
    }
}
