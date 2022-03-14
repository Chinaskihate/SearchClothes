using AutoMapper;
using MediatR;
using SearchClothes.Application.Common.Exceptions;
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
            var oldPost = user.CreatedPosts.FirstOrDefault(p => p.Id == request.PostId);
            var postWithNewTitle = user.CreatedPosts.FirstOrDefault(p => p.Title == request.Title);
            if (oldPost == null || (postWithNewTitle != null && oldPost.Id != postWithNewTitle.Id))
            {
                throw new PostAlreadyExistsException(user.Id, request.Title);
            }

            var newPost = await _postService.UpdatePost(user.Id,
                (request.PostId,
                request.Title,
                request.Description,
                request.SellerLink,
                request.Tags));
            return _mapper.Map<PostLookupDto>(newPost);
        }
    }
}
