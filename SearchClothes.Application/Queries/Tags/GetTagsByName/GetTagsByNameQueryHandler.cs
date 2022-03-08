using MediatR;
using SearchClothes.Application.Interfaces.Authentication;
using SearchClothes.Application.Interfaces.Tags;
using SearchClothes.Application.Interfaces.Users;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Queries.Tags.GetTagsByName
{
    public class GetTagsByNameQueryHandler : IRequestHandler<GetTagsByNameQuery, IEnumerable<Tag>>
    {
        private readonly ITagService _tagService;
        private readonly IUserService _userService;

        public GetTagsByNameQueryHandler(ITagService tagService, IUserService userService)
        {
            _tagService = tagService;
            _userService = userService;
        }

        public async Task<IEnumerable<Tag>> Handle(GetTagsByNameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByToken(request.Token);
            if (user == null)
            {
                return new List<Tag>();
            }
            var tags = await _tagService.GetByName(request.Name);
            return tags;
        }
    }
}
