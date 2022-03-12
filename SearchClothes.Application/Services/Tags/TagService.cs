using AutoMapper;
using SearchClothes.Application.Common.Tags;
using SearchClothes.Application.Interfaces.DataServices;
using SearchClothes.Application.Interfaces.Tags;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Services.Tags
{
    public class TagService : ITagService
    {
        private readonly ITagDataService _tagDataService;
        private readonly IMapper _mapper;

        public TagService(ITagDataService dataService, IMapper mapper)
        {
            _tagDataService = dataService;
            _mapper = mapper;
        }

        public async Task<bool> CreateTag(string name, Guid creatorId)
        {
            var tags = await _tagDataService.GetByName(name);
            if (tags.Count() != 0)
            {
                return false;
            }
            var newTag = new Tag()
            {
                Name = name,
                CreatorId = creatorId,
                Posts = new List<Post>()
            };
            await _tagDataService.Create(newTag);
            return true;
        }

        public async Task<IEnumerable<Tag>> GetAllTags()
        {
            return await _tagDataService.GetAll();
        }

        public async Task<IEnumerable<Tag>> GetByName(string name)
        {
            return await _tagDataService.GetByName(name);
        }

        public async Task<bool> Exists(IEnumerable<TagLookupDto> tagsDto)
        {
            var tags = tagsDto.Select(dto => _mapper.Map<Tag>(dto));
            return await _tagDataService.Exists(tags);
        }

        public async Task<IEnumerable<Tag>> ConvertDtoToTags(IEnumerable<TagLookupDto> tagsDto)
        {
            var tags = tagsDto.Select(dto => _mapper.Map<Tag>(dto)).ToList();
            var allTags = await _tagDataService.GetAll();
            return allTags.Intersect(tags);
        }
    }
}
