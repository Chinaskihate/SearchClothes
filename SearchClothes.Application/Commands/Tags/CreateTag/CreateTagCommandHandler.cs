using MediatR;
using SearchClothes.Application.Interfaces.Authentication;
using SearchClothes.Application.Interfaces.DataServices;
using SearchClothes.Application.Interfaces.Tags;
using SearchClothes.Application.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Tags.CreateTag
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, bool>
    {
        private ITagService _tagService;
        private IUserService _userService;

        public CreateTagCommandHandler(ITagService tagService, IUserService userService)
        {
            _tagService = tagService;
            _userService = userService;
        }

        public async Task<bool> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByToken(request.Token);
            if (user == null)
            {
                return false;
            }
            var result = await _tagService.CreateTag(request.Name, user.Id);
            return result;
        }
    }
}
