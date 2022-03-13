using MediatR;
using System;

namespace SearchClothes.Application.Commands.Posts.DeletePost
{
    public class DeletePostCommand : TokenizedCommand, IRequest<bool>
    {
        public Guid PostId { get; set; }
    }
}
