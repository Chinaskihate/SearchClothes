using MediatR;
using SearchClothes.Application.Interfaces.Posts;
using SearchClothes.Application.Interfaces.Rates;
using SearchClothes.Application.Interfaces.Users;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Rates.RatePost
{
    public class RatePostCommandHandler : IRequestHandler<RatePostCommand, bool>
    {
        private readonly IRateService _rateService;
        private readonly IUserService _userService;
        private readonly IPostService _postService;

        public RatePostCommandHandler(IRateService rateService, IUserService userService, IPostService postService)
        {
            _rateService = rateService;
            _userService = userService;
            _postService = postService;
        }

        public async Task<bool> Handle(RatePostCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByToken(request.Token);
            if (user == null)
            {
                return false;
            }
            var post = await _postService.GetPostById(request.PostId);
            if (post == null)
            {
                return false;
            }
            var result = await _rateService.RatePost(user, post, request.Rate);
            if (!result)
            {
                return false;
            }
            return true;
        }
    }
}
