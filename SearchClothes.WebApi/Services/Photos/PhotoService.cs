﻿using Microsoft.AspNetCore.Hosting;
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

        public Task<IFormFile> GetPhoto(Guid postId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SavePhoto(Guid postId, IFormFile photo)
        {
            string fileName = postId.ToString();
            var physicalPath = _env.ContentRootPath + "/Photos/" + fileName;
            using(var stream = new FileStream(physicalPath, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }
            return true;
        }
    }
}
