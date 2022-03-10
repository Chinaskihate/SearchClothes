using MediatR;
using SearchClothes.Application.Interfaces.Photos;
using SearchClothes.Application.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Queries.Photos
{
    public class DownloadPhotoQueryHandler : IRequestHandler<DownloadPhotoQuery, byte[]>
    {
        private IPhotoService _photoService;
        private IUserService _userService;

        public DownloadPhotoQueryHandler(IPhotoService photoService, IUserService userService)
        {
            _photoService = photoService;
            _userService = userService;
        }

        public async Task<byte[]> Handle(DownloadPhotoQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByToken(request.Token);
            if (user == null)
            {
                return null;
            }
            return await _photoService.DownloadPhoto(request.PostId);
        }
    }
}
