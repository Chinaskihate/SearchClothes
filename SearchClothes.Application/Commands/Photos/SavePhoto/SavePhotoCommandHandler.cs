using MediatR;
using SearchClothes.Application.Interfaces.Photos;
using SearchClothes.Application.Interfaces.Users;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Photos.SavePhoto
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
            var user = await _userService.GetByToken(request.Token);
            return await _photoService.SavePhoto(request.PostId, request.Photo);
        }
    }
}
