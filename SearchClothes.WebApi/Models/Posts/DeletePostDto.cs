using AutoMapper;
using SearchClothes.Application.Commands.Posts.DeletePost;
using SearchClothes.Application.Common.Mappings;
using System;

namespace SearchClothes.WebApi.Models.Posts
{
    public class DeletePostDto : TokenDto, IMapWith<DeletePostCommand>
    {
        public Guid PostId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeletePostDto, DeletePostCommand>()
                .ForMember(deleteCommand => deleteCommand.Token,
                opt => opt.MapFrom(deleteDto => deleteDto.Token))
                .ForMember(deleteCommand => deleteCommand.PostId,
                opt => opt.MapFrom(deleteDto => deleteDto.PostId));
        }
    }
}
