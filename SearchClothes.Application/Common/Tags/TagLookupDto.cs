using AutoMapper;
using SearchClothes.Application.Common.Mappings;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;

namespace SearchClothes.Application.Common.Tags
{
    public class TagLookupDto : IMapWith<Tag>
    {
        public Guid Id { get; set; }

        public Guid CreatorId { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tag, TagLookupDto>()
                .ForMember(tagDto => tagDto.Id,
                opt => opt.MapFrom(tag => tag.Id))
                .ForMember(tagDto => tagDto.CreatorId,
                opt => opt.MapFrom(tag => tag.CreatorId))
                .ForMember(tagDto => tagDto.Name,
                opt => opt.MapFrom(tag => tag.Name));

            profile.CreateMap<TagLookupDto, Tag>()
                .ForMember(tag => tag.Id,
                opt => opt.MapFrom(tagDto => tagDto.Id))
                .ForMember(tag => tag.CreatorId,
                opt => opt.MapFrom(tagDto => tagDto.CreatorId))
                .ForMember(tag => tag.Name,
                opt => opt.MapFrom(tagDto => tagDto.Name))
                .ForMember(tag=>tag.Posts,
                opt => opt.MapFrom(tagDto => new List<Post>() ));
        }
    }
}
