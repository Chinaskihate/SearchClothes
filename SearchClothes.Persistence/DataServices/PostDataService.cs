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
    public class PostDataService : IPostDataService   
    {
        private readonly GenericDataService<Post> _dataService;
        private SearchClothesDbContext _dbContext;

        public PostDataService(SearchClothesDbContext dbContext)
        {
            _dataService = new GenericDataService<Post>(dbContext);
            _dbContext = dbContext;
        }

        public async Task<Post> Create(Post entity)
        {
            return await _dataService.Create(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _dataService.Delete(id);
        }

        public async Task<Post> Get(Guid id) 
        {
            var entity = await _dbContext.Posts
                .Include(post => post.Tags)
                .Include(post => post.Rates)
                .FirstOrDefaultAsync(post => post.Id == id);
            return entity;
        }

        public async Task<IEnumerable<Post>> GetPosts(string title, IEnumerable<Tag> tags, double minRate)
        {
            var entity = await _dbContext.Posts
                .Include(post => post.Tags)
                .Include(post => post.Rates)
                .Where(post => post.Title.Contains(title))
                .Where(post => post.Rates.Count() == 0 ? true : post.Rates.Average(r => r.Value) >= minRate)
                .ToListAsync();
            entity = entity
                .Where(post => !tags.Except(post.Tags).Any())
                .ToList();
            return entity;
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            var entity = await _dbContext.Posts
                .Include(post => post.Tags)
                .Include(post => post.Rates)
                .ToListAsync();
            return entity;
        }

        public async Task<IEnumerable<Post>> GetByCreatorId(Guid creatorId)
        {
            var entity = await _dbContext.Posts
                .Include(post => post.Tags)
                .Include(post => post.Rates)
                .Where(post => post.CreatorId == creatorId)
                .ToListAsync();
            return entity;
        }

        public async Task<IEnumerable<Post>> GetByRate(double rate)
        {
            var entity = await _dbContext.Posts
                .Include(post => post.Tags)
                .Include(post => post.Rates)
                .Where(post => post.Rates.Average(x => x.Value) >= rate)
                .ToListAsync();
            return entity;
        }

        public async Task<IEnumerable<Post>> GetByTags(IEnumerable<Tag> tags)
        {
            var entity = await _dbContext.Posts
                .Include(post => post.Tags)
                .Include(post => post.Rates)
                .Where(post => !tags.Except(post.Tags).Any())
                .ToListAsync();
            return entity;
        }

        public async Task<IEnumerable<Post>> GetByTitle(string title)
        {
            var entity = await _dbContext.Posts
                .Include(post => post.Tags)
                .Include(post => post.Rates)
                .Where(post => post.Title.Contains(title))
                .ToListAsync();
            return entity;
        }

        public async Task<Post> Update(Guid id, Post entity)
        {
            return await _dataService.Update(id, entity);
        }
    }
}
