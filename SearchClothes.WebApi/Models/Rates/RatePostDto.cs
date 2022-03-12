using AutoMapper;
using SearchClothes.Application.Commands.Rates.RatePost;
using SearchClothes.Application.Common.Mappings;
using System;

namespace SearchClothes.WebApi.Models.Rates
{
    public class RatePostDto : TokenDto, IMapWith<RatePostCommand>
    {
        public Guid PostId { get; set; }

        public int Rate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RatePostDto, RatePostCommand>();
                //.ForMember(rateCommand => rateCommand.Token,
                //opt => opt.MapFrom(rateDto => rateDto.Token))
                //.ForMember(rateCommand => rateCommand.PostId,
                //opt => opt.MapFrom(rateDto => rateDto.PostId))
                //.ForMember(rateCommand => rateCommand.Rate,
                //opt => opt.MapFrom(rateDto => rateDto.Rate));
        }
    }
}
