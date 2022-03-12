using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchClothes.Application.Interfaces.DataServices
{
    public interface IRateDataService : IDataService<Rate>
    {
        Task<IEnumerable<Rate>> GetByUserId(Guid id);
    }
}
