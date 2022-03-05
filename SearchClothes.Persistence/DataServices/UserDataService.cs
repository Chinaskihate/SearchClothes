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
    public class UserDataService : IUserService
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
            return await _dataService.Get(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dataService.GetAll();
        }

        public async Task<User> GetByEmail(string email)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            return entity;
        }

        public async Task<User> Update(Guid id, User entity)
        {
            return await _dataService.Update(id, entity);
        }
    }
}
