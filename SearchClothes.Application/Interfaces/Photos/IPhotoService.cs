using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Interfaces.Photos
{
    public interface IPhotoService
    {
        public Task<bool> SavePhoto(Guid postId, IFormFile photo);

        public Task<byte[]> DownloadPhoto(Guid postId);

        public Task<bool> DeletePhoto(Guid postId);
    }
}
