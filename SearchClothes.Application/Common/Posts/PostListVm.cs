using AutoMapper;
using SearchClothes.Application.Common.Mappings;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Common.Posts
{
    public class PostListVm : IMapWith<IEnumerable<Post>>
    {
        public IList<PostLookupDto> Posts { get; set; }
    
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IEnumerable<Post>, PostListVm>()
                .AfterMap((src, dest, context) =>
                {
                    dest.Posts = src.Select(p => context.Mapper.Map<PostLookupDto>(p)).ToList();
                });
        } 
    }
}
