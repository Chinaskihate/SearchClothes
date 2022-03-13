using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace SearchClothes.Application.Commands.Photos.SavePhoto
{
    public class SavePhotoCommand : TokenizedCommand, IRequest<bool>
    {
        public Guid PostId { get; set; }

        public IFormFile Photo { get; set; }
    }
}
