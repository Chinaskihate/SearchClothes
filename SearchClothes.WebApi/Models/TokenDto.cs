﻿using AutoMapper;
using SearchClothes.Application.Common.Mappings;
using SearchClothes.Application.Queries.Posts.GetUserPosts;
using SearchClothes.Application.Queries.Tags.GetAllTags;
using System;

namespace SearchClothes.WebApi.Models
{
    public class TokenDto : IMapWith<GetAllTagsQuery>, IMapWith<GetUserPostsQuery>
    {
        public Guid Token { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TokenDto, GetAllTagsQuery>()
                .ForMember(getQuery => getQuery.Token,
                opt => opt.MapFrom(tokenDto => tokenDto.Token));

            profile.CreateMap<TokenDto, GetUserPostsQuery>()
                .ForMember(getQuery => getQuery.Token,
                opt => opt.MapFrom(tokenDto => tokenDto.Token));
        }
    }
}