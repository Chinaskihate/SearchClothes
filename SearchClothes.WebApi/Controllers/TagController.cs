using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SearchClothes.Application.Commands.Tags.CreateTag;
using SearchClothes.Application.Queries.Tags.GetAllTags;
using SearchClothes.Application.Queries.Tags.GetTagsByName;
using SearchClothes.Domain.Models;
using SearchClothes.WebApi.Models;
using SearchClothes.WebApi.Models.Tags;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchClothes.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TagController : BaseController
    {
        private readonly IMapper _mapper;

        public TagController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> Create([FromBody] CreateTagDto createTagDto)
        {
            var command = _mapper.Map<CreateTagCommand>(createTagDto);
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<IEnumerable<Tag>>> GetAll([FromBody] TokenDto tokenDto)
        {
            var command = _mapper.Map<GetAllTagsQuery>(tokenDto);
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("get-by-name")]
        public async Task<ActionResult<IEnumerable<Tag>>> GetByName([FromBody] GetTagsByNameDto getTagsByNameDto)
        {
            var command = _mapper.Map<GetTagsByNameQuery>(getTagsByNameDto);
            var tags = await Mediator.Send(command);
            return Ok(tags);
        }
    }
}
