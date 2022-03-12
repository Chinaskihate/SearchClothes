using AutoMapper;
using SearchClothes.Application.Common.Mappings;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Common.Tags
{
    public class TagListVm : IMapWith<IEnumerable<Tag>>
    {
        public IList<TagLookupDto> Tags { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<IEnumerable<Tag>, TagListVm>()
                .AfterMap((src, dest, context) =>
                {
                    dest.Tags = src.Select(tag => context.Mapper.Map<TagLookupDto>(tag)).ToList();
                });
        }
    }
}
