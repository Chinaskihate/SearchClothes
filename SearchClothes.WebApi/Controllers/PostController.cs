using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using SearchClothes.Application.Commands.Photos;
using SearchClothes.Application.Commands.Posts.CreatePost;
using SearchClothes.Application.Interfaces.Posts;
using SearchClothes.Application.Queries.Posts.Common;
using SearchClothes.Application.Queries.Posts.GetPosts;
using SearchClothes.Application.Queries.Posts.GetUserPosts;
using SearchClothes.Domain.Models;
using SearchClothes.WebApi.Models;
using SearchClothes.WebApi.Models.Photos;
using SearchClothes.WebApi.Models.Posts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchClothes.WebApi.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class PostController : BaseController
    {
        private readonly IMapper _mapper;

        public PostController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Post>> Create([FromBody] CreatePostDto createPostDto)
        {
            var postCommand = _mapper.Map<CreatePostCommand>(createPostDto);
            var result = await Mediator.Send(postCommand);
            return Ok(result);
        }

        [HttpPost("save-photo")]
        public async Task<ActionResult<bool>> SavePhoto([FromQuery] Guid token, Guid postId)
        {
            var photoDto = new PhotoDto()
            {
                Token = token,
                PostId = postId,
                Photo = Request.Form.Files[0]
            };
            var saveCommand = _mapper.Map<SavePhotoCommand>(photoDto);
            var result = await Mediator.Send(saveCommand);
            return Ok(result);
        }

        [HttpPost("get-posts")]
        public async Task<ActionResult<PostListVm>> GetPosts(GetPostsDto getPostsDto)
        {
            var postsCommand = _mapper.Map<GetPostsQuery>(getPostsDto);
            var result = await Mediator.Send(postsCommand);
            return Ok(result);
        }

        [HttpPost("get-user-posts")]
        public async Task<ActionResult<PostListVm>> GetUserPosts(TokenDto tokenDto)
        {
            var postsCommand = _mapper.Map<GetUserPostsQuery>(tokenDto);
            var result = await Mediator.Send(postsCommand);
            return Ok(result);
        }
    }
}