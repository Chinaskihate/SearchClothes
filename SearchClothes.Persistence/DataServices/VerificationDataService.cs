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
    public class VerificationDataService : IVerificationService
    {
        // TODO: think about inheritance here.
        private GenericDataService<Verification> _dataService;
        private SearchClothesDbContext _dbContext;

        public VerificationDataService(SearchClothesDbContext dbContext)
        {
            _dataService = new GenericDataService<Verification>(dbContext);
            _dbContext = dbContext;
        }

        public async Task<Verification> Create(Verification entity)
        {
            return await _dataService.Create(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _dataService.Delete(id);
        }

        public async Task<Verification> Get(Guid id)
        {
            return await _dataService.Get(id);
        }

        public async Task<IEnumerable<Verification>> GetAll()
        {
            return await _dataService.GetAll();
        }

        public async Task<Verification> GetByEmail(string email)
        {
            var entity = await _dbContext.Verifications.FirstOrDefaultAsync(x => x.Email == email);
            return entity;
        }

        public async Task<Verification> GetByUsername(string username)
        {
            var entity = await _dbContext.Verifications.FirstOrDefaultAsync(x => x.Username == username);
            return entity;
        }

        public async Task<Verification> Update(Guid id, Verification entity)
        {
            return await _dataService.Update(id, entity);
        }
    }
}
