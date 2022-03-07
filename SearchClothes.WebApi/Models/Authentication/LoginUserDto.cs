using AutoMapper;
using SearchClothes.Application.Commands.Users.Login;
using SearchClothes.Application.Common.Mappings;

namespace SearchClothes.WebApi.Models.Authentication
{
    public class LoginUserDto : IMapWith<LoginUserCommand>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginUserDto, LoginUserCommand>()
                .ForMember(loginCommand => loginCommand.Email,
                opt => opt.MapFrom(loginDto => loginDto.Email))
                .ForMember(loginCommand => loginCommand.Password,
                opt => opt.MapFrom(loginDto => loginDto.Password));
        }
    }
}
