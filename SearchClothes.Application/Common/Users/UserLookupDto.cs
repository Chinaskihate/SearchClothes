using AutoMapper;
using AutoMapper.QueryableExtensions;
using SearchClothes.Application.Common.Mappings;
using SearchClothes.Application.Common.Posts;
using SearchClothes.Domain.Models;
using System;
using System.Linq;

namespace SearchClothes.Application.Common.Users
{
    public class UserLookupDto : IMapWith<User>
    {
        public Guid Id { get; set; }

        public Guid Token { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public PostListVm CreatedPosts { get; set; }

        public PostListVm RatedPosts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserLookupDto>()
                .ForMember(userDto => userDto.Id,
                opt => opt.MapFrom(user => user.Id))
                .ForMember(userDto => userDto.Token,
                opt => opt.MapFrom(user => user.Token))
                .ForMember(userDto => userDto.Username,
                opt => opt.MapFrom(user => user.Username))
                .ForMember(userDto => userDto.Email,
                opt => opt.MapFrom(user => user.Email))
                .AfterMap((src, dest, context) =>
                {
                    dest.CreatedPosts = context.Mapper.Map<PostListVm>(src.CreatedPosts);
                    dest.RatedPosts = context.Mapper.Map<PostListVm>(src.RatedPosts);
                });
        } 
    }
}
