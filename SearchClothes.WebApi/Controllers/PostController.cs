using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SearchClothes.Application.Commands.Photos.DeletePhoto;
using SearchClothes.Application.Commands.Photos.SavePhoto;
using SearchClothes.Application.Commands.Posts.CreatePost;
using SearchClothes.Application.Commands.Posts.DeletePost;
using SearchClothes.Application.Commands.Posts.UpdatePost;
using SearchClothes.Application.Common.Posts;
using SearchClothes.Application.Queries.Photos.DownloadPhoto;
using SearchClothes.Application.Queries.Posts.GetPosts;
using SearchClothes.Application.Queries.Posts.GetUserPosts;
using SearchClothes.Domain.Models;
using SearchClothes.WebApi.Models;
using SearchClothes.WebApi.Models.Photos;
using SearchClothes.WebApi.Models.Posts;
using System;
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
        public async Task<ActionResult<PostLookupDto>> Create([FromBody] CreatePostDto createPostDto)
        {
            var createCommand = _mapper.Map<CreatePostCommand>(createPostDto);
            var result = await Mediator.Send(createCommand);
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

        [HttpDelete("delete-post")]
        public async Task<ActionResult<bool>> Delete(DeletePostDto deleteDto)
        {
            var deletePostCommand = _mapper.Map<DeletePostCommand>(deleteDto);
            var result = await Mediator.Send(deletePostCommand);
            var deletePhotoDto = new PhotoDto()
            {
                Token = deleteDto.Token,
                PostId = deleteDto.PostId
            };
            var deletePhotoCommand = _mapper.Map<DeletePhotoCommand>(deletePhotoDto);
            await Mediator.Send(deletePhotoCommand);
            return Ok(result);
        }

        [HttpPut("update-post")]
        public async Task<ActionResult<PostLookupDto>> Update(UpdatePostDto updateDto)
        {
            var updateCommand = _mapper.Map<UpdatePostCommand>(updateDto);
            var result = await Mediator.Send(updateCommand);
            return Ok(result);
        }

        [HttpGet("download-photo")]
        public async Task<ActionResult> DownloadPhoto([FromQuery] Guid token, Guid postId)
        {
            var downloadDto = new PhotoDto()
            {
                Token = token,
                PostId = postId
            };
            var downloadCommand = _mapper.Map<DownloadPhotoQuery>(downloadDto);
            var result = await Mediator.Send(downloadCommand);
            return result == null ? NotFound(downloadDto) : File(result, "image/png");
        }
    }
}