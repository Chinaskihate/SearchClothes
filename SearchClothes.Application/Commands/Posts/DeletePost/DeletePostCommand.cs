using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Posts.DeletePost
{
    public class DeletePostCommand : IRequest<bool>
    {
        public Guid Token { get; set; }

        public Guid PostId { get; set; }
    }
}
