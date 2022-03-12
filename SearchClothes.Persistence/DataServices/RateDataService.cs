using SearchClothes.Application.Interfaces.DataServices;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Persistence.DataServices
{
    public class RateDataService : IRateDataService
    {
        private readonly GenericDataService<Rate> _dataService;
        private readonly SearchClothesDbContext _dbContext;

        public RateDataService(SearchClothesDbContext dbContext)
        {
            _dataService = new GenericDataService<Rate>(dbContext);
            _dbContext = dbContext;
        }

        public async Task<Rate> Create(Rate entity)
        {
            return await _dataService.Create(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _dataService.Delete(id);
        }

        public async Task<Rate> Get(Guid id)
        {
            return await _dataService.Get(id);
        }

        public async Task<IEnumerable<Rate>> GetAll()
        {
            return await _dataService.GetAll();
        }

        public async Task<IEnumerable<Rate>> GetByUserId(Guid id)
        {
            var rates = _dbContext.Rates.Where(r => r.UserId == id);
            return rates.ToList();
        }

        public async Task<Rate> Update(Guid id, Rate entity)
        {
            return await _dataService.Update(id, entity);
        }
    }
}
