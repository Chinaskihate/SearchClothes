using SearchClothes.Application.Common.Tags;
using SearchClothes.Application.Interfaces.DataServices;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Interfaces.Tags
{
    public interface ITagService
    {
        Task<bool> CreateTag(string name, Guid creatorId);

        Task<IEnumerable<Tag>> GetAllTags();

        Task<IEnumerable<Tag>> GetByName(string name);

        Task<bool> Exists(IEnumerable<TagLookupDto> tagsDto);

        Task<IEnumerable<Tag>> ConvertDtoToTags(IEnumerable<TagLookupDto> tagsDto);
    }
}
