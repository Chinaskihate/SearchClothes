using MediatR;
using SearchClothes.Application.Interfaces.Posts;
using SearchClothes.Application.Interfaces.Users;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Posts.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, bool>
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;

        public DeletePostCommandHandler(IPostService postService, IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        public async Task<bool> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByToken(request.Token);
            var result = await _postService.RemovePost(user.Id, request.PostId);
            return result;
        }
    }
}
