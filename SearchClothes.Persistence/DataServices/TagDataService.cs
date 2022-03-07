using Microsoft.EntityFrameworkCore;
using SearchClothes.Application.Interfaces.DataServices;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Persistence.DataServices
{
    public class TagDataService : ITagDataService
    {
        private GenericDataService<Tag> _dataService;
        private SearchClothesDbContext _dbContext;

        public TagDataService(SearchClothesDbContext dbContext)
        {
            _dataService = new GenericDataService<Tag>(dbContext);
            _dbContext = dbContext;
        }

        public async Task<Tag> Create(Tag entity)
        {
            return await _dataService.Create(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _dataService.Delete(id);
        }

        public async Task<Tag> Get(Guid id)
        {
            return await _dataService.Get(id);
        }

        public async Task<IEnumerable<Tag>> GetAll()
        {
            return await _dataService.GetAll();
        }

        public async Task<IEnumerable<Tag>> GetByName(string name)
        {
            var tags = await _dbContext.Tags
                .Where(t => t.Name.Contains(name))
                .ToListAsync();
            return tags;
        }

        public async Task<Tag> Update(Guid id, Tag entity)
        {
            return await _dataService.Update(id, entity);
        }
    }
}
