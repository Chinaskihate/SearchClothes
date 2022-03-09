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

namespace SearchClothes.Application.Queries.Posts.GetPosts
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, PostListVm>
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public GetPostsQueryHandler(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        public async Task<PostListVm> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            // TODO:remove AsQueryable
            var posts = await _postService.GetPosts(request.Title, request.Tags, request.MinimumRate);

            var postsQuery = posts.AsQueryable();
            var postsProjected = postsQuery.ProjectTo<PostLookupDto>(_mapper.ConfigurationProvider);

            var postsList = postsProjected.ToList();
            return new PostListVm() { Posts = postsList };
        }
    }
}
