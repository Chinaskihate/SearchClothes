﻿using AutoMapper;
using SearchClothes.Application.Common.Mappings;
using SearchClothes.Application.Users.Commands.VerificateUser;
using System;

namespace SearchClothes.WebApi.Models
{
    public class VerificateUserDto : IMapWith<VerificateUserCommand>
    {
        public string Email { get; set; }

        public Guid VerificationCode { get; set; }
    
        public void Mapping(Profile profile)
        {
            profile.CreateMap<VerificateUserDto, VerificateUserCommand>()
                .ForMember(verificateCommand => verificateCommand.Email,
                opt => opt.MapFrom(verificateDto => verificateDto.Email))
                .ForMember(verificateCommand => verificateCommand.VerificationCode,
                opt => opt.MapFrom(verificateDto => verificateDto.VerificationCode));
        }
    }
}
