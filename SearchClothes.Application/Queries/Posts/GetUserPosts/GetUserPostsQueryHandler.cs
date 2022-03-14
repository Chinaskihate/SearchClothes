using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SearchClothes.Application.Common.Posts;
using SearchClothes.Application.Interfaces.Posts;
using SearchClothes.Application.Interfaces.Users;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Queries.Posts.GetUserPosts
{
    public class GetUserPostsQueryHandler : IRequestHandler<GetUserPostsQuery, PostListVm>
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetUserPostsQueryHandler(IPostService postService, IMapper mapper, IUserService userService)
        {
            _postService = postService;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<PostListVm> Handle(GetUserPostsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByToken(request.Token);
            var userPosts = await _postService.GetUserPosts(user.Id);
            var postListVm = _mapper.Map<PostListVm>(userPosts);

            return postListVm;
        }
    }
}
