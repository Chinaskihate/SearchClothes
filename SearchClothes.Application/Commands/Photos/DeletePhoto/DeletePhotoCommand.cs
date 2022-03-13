using MediatR;
using System;

namespace SearchClothes.Application.Commands.Photos.DeletePhoto
{
    public class DeletePhotoCommand : TokenizedCommand, IRequest<bool>
    {
        public Guid PostId { get; set; }
    }
}
