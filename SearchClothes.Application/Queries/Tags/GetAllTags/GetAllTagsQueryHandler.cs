using AutoMapper;
using MediatR;
using SearchClothes.Application.Common.Tags;
using SearchClothes.Application.Interfaces.Tags;
using SearchClothes.Application.Interfaces.Users;
using SearchClothes.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Queries.Tags.GetAllTags
{
    public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, TagListVm>
    {
        private readonly ITagService _tagService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetAllTagsQueryHandler(ITagService tagService, IUserService userService, IMapper mapper)
        {
            _tagService = tagService;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<TagListVm> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByToken(request.Token);
            if (user == null)
            {
                return new TagListVm();
            }
            var tags = await _tagService.GetAllTags();
            var tagListVm = _mapper.Map<TagListVm>(tags);
            return tagListVm;
        }
    }
}
