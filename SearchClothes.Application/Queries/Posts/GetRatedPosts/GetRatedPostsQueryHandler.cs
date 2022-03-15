using AutoMapper;
using FluentValidation;
using MediatR;
using SearchClothes.Application.Common.Posts;
using SearchClothes.Application.Interfaces.Posts;
using SearchClothes.Application.Interfaces.Users;
using SearchClothes.Application.Queries.Posts.GetUserPosts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Queries.Posts.GetRatedPosts
{
    public class GetRatedPostsQueryHandler : IRequestHandler<GetRatedPostsQuery, PostListVm>
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetRatedPostsQueryHandler(IPostService postService, IMapper mapper, IUserService userService)
        {
            _postService = postService;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<PostListVm> Handle(GetRatedPostsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByToken(request.Token);
            // var ratedPosts = await _postService.GetUserPosts(user.Id);
            var postListVm = _mapper.Map<PostListVm>(user.RatedPosts);

            return postListVm;
        }
    }
}
