using MediatR;
using System;

namespace SearchClothes.Application.Commands.Rates.RatePost
{
    public class RatePostCommand : TokenizedCommand, IRequest<bool>
    {
        public Guid PostId { get; set; }

        public int Rate { get; set; }
    }
}
