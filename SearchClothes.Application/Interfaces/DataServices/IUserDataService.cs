using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Interfaces.DataServices
{
    public interface IUserDataService : IDataService<User>
    {
        public Task<User> GetByEmail(string email);

        public Task<User> GetByToken(Guid token);
    }
}
