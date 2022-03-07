using MediatR;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Queries.Tags.GetAllTags
{
    public class GetAllTagsQuery : IRequest<IEnumerable<Tag>>
    {
        public Guid Token { get; set; }
    }
}
