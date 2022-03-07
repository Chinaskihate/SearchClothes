using MediatR;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Queries.Users
{
    public class GetUserByTokenQuery : IRequest<User>
    {
        public Guid Token { get; set; }
    }
}
