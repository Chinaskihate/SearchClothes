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
    public class UserDataService : IUserDataService
    {
        private GenericDataService<User> _dataService;
        private SearchClothesDbContext _dbContext;

        public UserDataService(SearchClothesDbContext dbContext)
        {
            _dataService = new GenericDataService<User>(dbContext);
            _dbContext = dbContext;
        }

        public async Task<User> Create(User entity)
        {
            return await _dataService.Create(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _dataService.Delete(id);
        }

        public async Task<User> Get(Guid id)
        {
            var entity = await _dbContext.Users
                .Include(user => user.RatedPosts)
                    .ThenInclude(p => p.Rates)
                .Include(user => user.RatedPosts)
                    .ThenInclude(p => p.Tags)
                .Include(user => user.CreatedPosts)
                    .ThenInclude(p => p.Rates)
                .Include(user => user.CreatedPosts)
                    .ThenInclude(p => p.Tags)
                .FirstOrDefaultAsync(user => user.Id == id);
            return entity;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var entities = await _dbContext.Users
                .Include(user => user.RatedPosts)
                .Include(user => user.CreatedPosts)
                .ToListAsync();
            return entities;
        }

        public async Task<User> GetByEmail(string email)
        {
            var entity = await _dbContext.Users
                .Include(user => user.RatedPosts)
                    .ThenInclude(p => p.Rates)
                .Include(user => user.RatedPosts)
                    .ThenInclude(p => p.Tags)
                .Include(user => user.CreatedPosts)
                    .ThenInclude(p => p.Rates)
                .Include(user => user.CreatedPosts)
                    .ThenInclude(p => p.Tags)
                .FirstOrDefaultAsync(user => user.Email == email);
            return entity;
        }

        public async Task<User> GetByToken(Guid token)
        {
            var entity = await _dbContext.Users
                .Include(user => user.RatedPosts)
                    .ThenInclude(p => p.Rates)
                .Include(user => user.RatedPosts)
                    .ThenInclude(p => p.Tags)
                .Include(user => user.CreatedPosts)
                    .ThenInclude(p => p.Rates)
                .Include(user => user.CreatedPosts)
                    .ThenInclude(p => p.Tags)
                .FirstOrDefaultAsync(user => user.Token == token);
            return entity;
        }

        public async Task<User> Update(Guid id, User entity)
        {
            return await _dataService.Update(id, entity);
        }
    }
}
