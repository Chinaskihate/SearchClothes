using MediatR;
using System;

namespace SearchClothes.Application.Commands.Rates.RatePost
{
    public class RatePostCommand : IRequest<bool>
    {
        public Guid Token { get; set; }

        public Guid PostId { get; set; }

        public int Rate { get; set; }
    }
}
