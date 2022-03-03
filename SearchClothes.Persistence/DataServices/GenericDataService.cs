using Microsoft.EntityFrameworkCore;
using SearchClothes.Application.Interfaces;
using SearchClothes.Application.Interfaces.DataServices;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Persistence.DataServices
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly SearchClothesDbContext _dbContext;

        public GenericDataService(SearchClothesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Create(T entity)
        {
            var createdResult = await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return createdResult.Entity;
        }

        public async Task<T> Get(Guid id)
        {
            var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var entities = await _dbContext.Set<T>().ToListAsync();

            return entities;
        }

        public async Task<T> Update(Guid id, T entity)
        {
            entity.Id = id;
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task<bool> Delete(Guid id)
        {
            var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
