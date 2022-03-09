using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SearchClothes.Application.Interfaces.Posts;
using SearchClothes.Application.Interfaces.Users;
using SearchClothes.Application.Queries.Posts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if (user == null)
            {
                return null;
            }
            var result = (await _postService.GetUserPosts(user.Id))
                .AsQueryable()
                .ProjectTo<PostLookupDto>(_mapper.ConfigurationProvider)
                .ToList();

            return new PostListVm() { Posts = result};
        }
    }
}
