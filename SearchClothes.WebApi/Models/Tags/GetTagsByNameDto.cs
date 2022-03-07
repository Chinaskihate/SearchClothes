using AutoMapper;
using SearchClothes.Application.Common.Mappings;
using SearchClothes.Application.Queries.Tags.GetTagsByName;

namespace SearchClothes.WebApi.Models.Tags
{
    public class GetTagsByNameDto : TokenDto, IMapWith<GetTagsByNameQuery>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetTagsByNameDto, GetTagsByNameQuery>()
                .ForMember(getCommand => getCommand.Token,
                opt => opt.MapFrom(getDto => getDto.Token))
                .ForMember(getCommand => getCommand.Name,
                opt => opt.MapFrom(getDto => getDto.Name));
        }
    }
}
