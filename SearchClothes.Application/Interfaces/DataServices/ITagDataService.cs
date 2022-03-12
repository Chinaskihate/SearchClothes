using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Interfaces.DataServices
{
    public interface ITagDataService : IDataService<Tag>
    {
        public Task<IEnumerable<Tag>> GetByName(string name);

        public Task<bool> Exists(IEnumerable<Tag> posts);
    }
}
