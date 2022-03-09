using AutoMapper;
using MediatR;
using SearchClothes.Application.Interfaces.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using SearchClothes.Domain.Models;
using SearchClothes.Application.Queries.Posts.Common;
using SearchClothes.Application.Interfaces.Users;

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

            var postsQuery = posts.AsQueryable();
            var postsProjected = postsQuery.ProjectTo<PostLookupDto>(_mapper.ConfigurationProvider);

            var postsList = postsProjected.ToList();
            return new PostListVm() { Posts = postsList };
        }
    }
}
