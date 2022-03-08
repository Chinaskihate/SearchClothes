using AutoMapper;
using Microsoft.AspNetCore.Http;
using SearchClothes.Application.Commands.Posts.CreatePost;
using SearchClothes.Application.Common.Mappings;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;

namespace SearchClothes.WebApi.Models.Posts
{
    public class CreatePostDto : TokenDto, IMapWith<CreatePostCommand>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string SellerLink { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePostDto, CreatePostCommand>()
                .ForMember(createCommand => createCommand.Token,
                opt => opt.MapFrom(createDto => createDto.Token))
                .ForMember(createCommand => createCommand.Title,
                opt => opt.MapFrom(createDto => createDto.Title))
                .ForMember(createCommand => createCommand.Description,
                opt => opt.MapFrom(createDto => createDto.Description))
                .ForMember(createCommand => createCommand.SellerLink,
                opt => opt.MapFrom(createDto => createDto.SellerLink))
                .ForMember(createCommand => createCommand.Tags,
                opt => opt.MapFrom(createDto => createDto.Tags));
        }
    }
}
