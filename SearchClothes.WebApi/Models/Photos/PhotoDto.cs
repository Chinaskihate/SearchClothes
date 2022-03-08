using AutoMapper;
using Microsoft.AspNetCore.Http;
using SearchClothes.Application.Commands.Photos;
using SearchClothes.Application.Common.Mappings;
using System;

namespace SearchClothes.WebApi.Models.Photos
{
    public class PhotoDto : TokenDto, IMapWith<SavePhotoCommand>
    {
        public Guid PostId { get; set; }
        public IFormFile Photo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PhotoDto, SavePhotoCommand>()
                .ForMember(saveCommand => saveCommand.Token,
                opt => opt.MapFrom(photoDto => photoDto.Token))
                .ForMember(saveCommand => saveCommand.PostId,
                opt => opt.MapFrom(photoDto => photoDto.PostId))
                .ForMember(saveCommand => saveCommand.Photo,
                opt => opt.MapFrom(photoDto => photoDto.Photo));
        }
    }
}
