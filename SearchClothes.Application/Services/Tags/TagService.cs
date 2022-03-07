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

        public TagService(ITagDataService dataService)
        {
            _tagDataService = dataService;
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
                CreatorId = creatorId
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
    }
}
