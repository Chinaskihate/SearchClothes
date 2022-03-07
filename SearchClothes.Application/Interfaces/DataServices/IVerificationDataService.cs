using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Interfaces.DataServices
{
    public interface IVerificationDataService : IDataService<Verification>
    {
        public Task<Verification> GetByEmail(string email);

        public Task<Verification> GetByUsername(string username);
    }
}
