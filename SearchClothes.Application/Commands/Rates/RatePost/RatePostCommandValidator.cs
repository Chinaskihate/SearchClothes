using FluentValidation;
using System;

namespace SearchClothes.Application.Commands.Rates.RatePost
{
    public class RatePostCommandValidator : AbstractValidator<RatePostCommand>
    {
        public RatePostCommandValidator()
        {
            RuleFor(ratePostCommand =>
                ratePostCommand.Token).NotEqual(Guid.Empty);
            RuleFor(ratePostCommand =>
                ratePostCommand.PostId).NotEqual(Guid.Empty);
            RuleFor(ratePostCommand =>
                ratePostCommand.Rate).Must(rate => rate >= 0 && rate <= 5);
        }
    }
}
