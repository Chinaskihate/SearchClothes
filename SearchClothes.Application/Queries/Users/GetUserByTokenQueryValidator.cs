using FluentValidation;
using System;

namespace SearchClothes.Application.Queries.Users
{
    public class GetUserByTokenQueryValidator : AbstractValidator<GetUserByTokenQuery>
    {
        public GetUserByTokenQueryValidator()
        {
            RuleFor(getUserByTokenQuery =>
                getUserByTokenQuery.Token).NotEqual(Guid.Empty);
        }
    }
}
