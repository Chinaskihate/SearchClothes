using MediatR;
using SearchClothes.Application.Interfaces.Authentication;
using SearchClothes.Application.Interfaces.Tags;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Queries.Tags.GetAllTags
{
    public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, IEnumerable<Tag>>
    {
        private readonly ITagService _tagService;
        private IAuthenticationService _authenticationService;

        public GetAllTagsQueryHandler(ITagService tagService, IAuthenticationService authenticationService)
        {
            _tagService = tagService;
            _authenticationService = authenticationService;
        }

        public async Task<IEnumerable<Tag>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var user = await _authenticationService.GetByToken(request.Token);
            if (user == null)
            {
                return new List<Tag>();
            }
            var result = await _tagService.GetAllTags();
            return result;
        }
    }
}
