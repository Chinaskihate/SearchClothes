using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using SearchClothes.Application.Commands.Photos;
using SearchClothes.Application.Commands.Posts.CreatePost;
using SearchClothes.Application.Interfaces.Posts;
using SearchClothes.Domain.Models;
using SearchClothes.WebApi.Models;
using SearchClothes.WebApi.Models.Photos;
using SearchClothes.WebApi.Models.Posts;
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

        //[HttpPost("SavePhoto")]
        //public async Task<ActionResult> SavePhoto(TokenDto tokenDto)
        //{
        //    var 
        //}
    }
}