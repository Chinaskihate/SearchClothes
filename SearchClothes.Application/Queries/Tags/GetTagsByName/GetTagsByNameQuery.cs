using MediatR;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Queries.Tags.GetTagsByName
{
    public class GetTagsByNameQuery : IRequest<IEnumerable<Tag>>
    {
        public Guid Token { get; set; }

        public string Name { get; set; }
    }
}
