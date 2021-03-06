using AutoMapper;
using SearchClothes.Application.Commands.Users.CreateUser;
using SearchClothes.Application.Common.Mappings;

namespace SearchClothes.WebApi.Models.Authentication
{
    public class CreateUserDto : IMapWith<CreateUserCommand>
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>()
                .ForMember(userCommand => userCommand.Username,
                opt => opt.MapFrom(userDto => userDto.Username))
                .ForMember(userCommand => userCommand.Email,
                opt => opt.MapFrom(userDto => userDto.Email))
                .ForMember(userCommand => userCommand.Password,
                opt => opt.MapFrom(userComand => userComand.Password));
        }
    }
}
