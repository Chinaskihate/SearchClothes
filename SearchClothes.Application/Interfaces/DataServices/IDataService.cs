using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Interfaces.DataServices
{
    public interface IDataService<T>
    {
        Task<T> Create(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<T> Get(Guid id);

        Task<T> Update(Guid id, T entity);

        Task<bool> Delete(Guid id);
    }
}
