using AutoMapper;
using SearchClothes.Application.Commands.Tags.CreateTag;
using SearchClothes.Application.Common.Mappings;
using SearchClothes.Domain.Models;
using System;

namespace SearchClothes.WebApi.Models.Tags
{
    public class CreateTagDto : TokenDto, IMapWith<CreateTagCommand>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTagDto, CreateTagCommand>()
                .ForMember(tagCommand => tagCommand.Name,
                opt => opt.MapFrom(tagDto => tagDto.Name))
                .ForMember(tagCommand => tagCommand.Token,
                opt => opt.MapFrom(tagDto => tagDto.Token));
        }
    }
}
