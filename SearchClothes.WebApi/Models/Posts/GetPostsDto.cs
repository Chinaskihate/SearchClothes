using AutoMapper;
using SearchClothes.Application.Common.Mappings;
using SearchClothes.Application.Common.Tags;
using SearchClothes.Application.Queries.Posts.GetPosts;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;

namespace SearchClothes.WebApi.Models.Posts
{
    public class GetPostsDto : TokenDto, IMapWith<GetPostsQuery>
    {
        public Guid Token { get; set; }

        public string Title { get; set; }
    
        public IEnumerable<TagLookupDto> Tags { get; set; }

        public double MinimumRate { get; set; }
    
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetPostsDto, GetPostsQuery>()
                .ForMember(getQuery => getQuery.Token,
                opt => opt.MapFrom(getDto => getDto.Token))
                .ForMember(getQuery => getQuery.Title,
                opt => opt.MapFrom(getDto => getDto.Title))
                .ForMember(getQuery => getQuery.Tags,
                opt => opt.MapFrom(getDto => getDto.Tags))
                .ForMember(getQuery => getQuery.MinimumRate,
                opt => opt.MapFrom(getDto => getDto.MinimumRate));
        }
    }
}
