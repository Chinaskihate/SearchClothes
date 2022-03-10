using MediatR;
using SearchClothes.Application.Interfaces.Photos;
using SearchClothes.Application.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Photos.DeletePhoto
{
    public class DeletePhotoCommandHandler : IRequestHandler<DeletePhotoCommand, bool>
    {
        private IPhotoService _photoService;
        private IUserService _userService;

        public DeletePhotoCommandHandler(IPhotoService photoService, IUserService userService)
        {
            _photoService = photoService;
            _userService = userService;
        }

        public async Task<bool> Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByToken(request.Token);
            if (user == null)
            {
                return false;
            }
            return await _photoService.DeletePhoto(request.PostId);
        }
    }
}
