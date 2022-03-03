using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Interfaces.DataServices
{
    public interface IUserService : IDataService<User>
    {
        public Task<User> GetByEmail(string email);
    }
}
