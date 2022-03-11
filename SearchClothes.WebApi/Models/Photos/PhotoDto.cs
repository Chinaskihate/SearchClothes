using AutoMapper;
using Microsoft.AspNetCore.Http;
using SearchClothes.Application.Commands.Photos.DeletePhoto;
using SearchClothes.Application.Commands.Photos.SavePhoto;
using SearchClothes.Application.Common.Mappings;
using SearchClothes.Application.Queries.Photos.DownloadPhoto;
using System;

namespace SearchClothes.WebApi.Models.Photos
{
    public class PhotoDto : TokenDto, IMapWith<SavePhotoCommand>, IMapWith<DownloadPhotoQuery>, IMapWith<DeletePhotoCommand>
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

            profile.CreateMap<PhotoDto, DownloadPhotoQuery>()
                .ForMember(downloadCommand => downloadCommand.Token,
                opt => opt.MapFrom(photoDto => photoDto.Token))
                .ForMember(downloadCommand => downloadCommand.PostId,
                opt => opt.MapFrom(photoDto => photoDto.PostId));

            profile.CreateMap<PhotoDto, DeletePhotoCommand>()
                .ForMember(deleteCommand => deleteCommand.Token,
                opt => opt.MapFrom(photoDto => photoDto.Token))
                .ForMember(deleteCommand => deleteCommand.PostId,
                opt => opt.MapFrom(photoDto => photoDto.PostId));
        }
    }
}
