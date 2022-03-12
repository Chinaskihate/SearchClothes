using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SearchClothes.Application.Common.Posts;
using SearchClothes.Application.Interfaces.Posts;
using SearchClothes.Application.Interfaces.Users;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Queries.Posts.GetPosts
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, PostListVm>
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetPostsQueryHandler(IPostService postService, IMapper mapper, IUserService userService)
        {
            _postService = postService;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<PostListVm> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByToken(request.Token);
            if (user == null)
            {
                return null;
            }

            var posts = await _postService.GetPosts(request.Title, request.Tags, request.MinimumRate);

            var postListVm = _mapper.Map<PostListVm>(posts);
            return postListVm;
        }
    }
}
