using MediatR;
using SearchClothes.Application.Interfaces.Photos;
using SearchClothes.Application.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Photos
{
    public class SavePhotoCommandHandler : IRequestHandler<SavePhotoCommand, bool>
    {
        private readonly IPhotoService _photoService;
        private readonly IUserService _userService;

        public SavePhotoCommandHandler(IUserService userService, IPhotoService photoService)
        {
            _userService = userService;
            _photoService = photoService;
        }

        public async Task<bool> Handle(SavePhotoCommand request, CancellationToken cancellationToken)
        {
            if (await _userService.GetByToken(request.Token) == null)
            {
                return false;
            }
            return await _photoService.SavePhoto(request.PostId, request.Photo);
        }
    }
}
