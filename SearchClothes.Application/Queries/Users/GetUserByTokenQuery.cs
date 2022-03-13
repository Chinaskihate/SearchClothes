using MediatR;
using SearchClothes.Domain.Models;
using System;

namespace SearchClothes.Application.Queries.Users
{
    public class GetUserByTokenQuery : IRequest<User>
    {
        public Guid Token { get; set; }
    }
}
