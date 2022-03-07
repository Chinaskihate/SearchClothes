using MediatR;
using SearchClothes.Application.Interfaces.Authentication;
using SearchClothes.Application.Interfaces.DataServices;
using SearchClothes.Application.Interfaces.Tags;
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
        private IAuthenticationService _authenticationService;

        public CreateTagCommandHandler(ITagService tagService, IAuthenticationService authenticationService)
        {
            _tagService = tagService;
            _authenticationService = authenticationService;
        }

        public async Task<bool> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var user = await _authenticationService.GetByToken(request.Token);
            if (user == null)
            {
                return false;
            }
            var result = await _tagService.CreateTag(request.Name, user.Id);
            return result;
        }
    }
}
