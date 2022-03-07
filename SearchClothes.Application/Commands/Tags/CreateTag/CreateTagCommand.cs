using MediatR;
using SearchClothes.Application.Interfaces.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Commands.Tags.CreateTag
{
    public class CreateTagCommand : IRequest<bool>
    {
        public Guid Token { get; set; }

        public string Name { get; set; }
    }
}
