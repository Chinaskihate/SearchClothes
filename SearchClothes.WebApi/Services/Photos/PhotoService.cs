using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SearchClothes.Application.Interfaces.Photos;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SearchClothes.WebApi.Services.Photos
{
    public class PhotoService : IPhotoService
    {
        private readonly IWebHostEnvironment _env;

        public PhotoService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<byte[]> DownloadPhoto(Guid postId)
        {
            string fileName = postId.ToString() + ".png";
            var physicalPath = _env.ContentRootPath + "/Photos/" + fileName;
            if (!File.Exists(physicalPath))
            {
                return null;
            }
            byte[] data = await File.ReadAllBytesAsync(physicalPath);
            return data;
        }

        public async Task<bool> SavePhoto(Guid postId, IFormFile photo)
        {
            string fileName = postId.ToString() + ".png";
            var physicalPath = _env.ContentRootPath + "/Photos/" + fileName;
            using (var stream = new FileStream(physicalPath, FileMode.OpenOrCreate))
            {
                await photo.CopyToAsync(stream);
            }
            return true;
        }

        public async Task<bool> DeletePhoto(Guid postId)
        {
            string fileName = postId.ToString() + ".png";
            var physicalPath = _env.ContentRootPath + "/Photos/" + fileName;
            if (!File.Exists(physicalPath))
            {
                return false;
            }
            File.Delete(physicalPath);
            return true;
        }
    }
}
