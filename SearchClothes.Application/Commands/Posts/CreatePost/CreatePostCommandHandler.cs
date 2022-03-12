using AutoMapper;
using MediatR;
using SearchClothes.Application.Common.Posts;
using SearchClothes.Application.Interfaces.Posts;
using SearchClothes.Application.Interfaces.Users;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Posts.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, PostLookupDto>
    {
        private IPostService _postService;
        private IUserService _userService;
        private IMapper _mapper;

        public CreatePostCommandHandler(IPostService postService, IUserService userService, IMapper mapper)
        {
            _postService = postService;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<PostLookupDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByToken(request.Token);
            if (user == null)
            {
                return null;
            }
            var newPost = await _postService.CreatePost((
                    user.Id,
                    request.Title,
                    request.Description,
                    request.SellerLink,
                    request.Tags
                ));
            if (newPost == null)
            {
                return null;
            }
            var postLookupDto = _mapper.Map<PostLookupDto>(newPost);
            return postLookupDto;
        }
    }
}
