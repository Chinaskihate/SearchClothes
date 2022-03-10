using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Queries.Photos
{
    public class DownloadPhotoQuery : IRequest<byte[]>
    {
        public Guid Token { get; set; }

        public Guid PostId { get; set; }
    }
}
