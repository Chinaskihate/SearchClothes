using AutoMapper;
using SearchClothes.Application.Commands.Posts.UpdatePost;
using SearchClothes.Application.Common.Mappings;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;

namespace SearchClothes.WebApi.Models.Posts
{
    public class UpdatePostDto : TokenDto, IMapWith<UpdatePostCommand>
    {
        public Guid PostId { get; set; }
        
        public string Title { get; set; }

        public string Description { get; set; }

        public string SellerLink { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePostDto, UpdatePostCommand>()
                .ForMember(updateCommand => updateCommand.Token,
                opt => opt.MapFrom(updateDto => updateDto.Token))
                .ForMember(updateCommand => updateCommand.PostId,
                opt => opt.MapFrom(updateDto => updateDto.PostId))
                .ForMember(updateCommand => updateCommand.Title,
                opt => opt.MapFrom(updateDto => updateDto.Title))
                .ForMember(updateCommand => updateCommand.Description,
                opt => opt.MapFrom(updateDto => updateDto.Description))
                .ForMember(updateCommand => updateCommand.SellerLink,
                opt => opt.MapFrom(updateDto => updateDto.SellerLink))
                .ForMember(updateCommand => updateCommand.Tags,
                opt => opt.MapFrom(updateDto => updateDto.Tags));
        }
    }
}
