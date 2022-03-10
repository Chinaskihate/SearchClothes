using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Photos.SavePhoto
{
    public class SavePhotoCommand : IRequest<bool>
    {
        public Guid Token { get; set; }

        public Guid PostId { get; set; }

        public IFormFile Photo { get; set; }
    }
}
