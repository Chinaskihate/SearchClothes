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
            // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Post> Create(Post entity)
        {
            var tags = entity.Tags;
            // TODO: check if it works without tags removing;
            entity.Tags = new List<Tag>();
            var newPost = await _dataService.Create(entity);

            entity.Tags = tags;
            newPost = await Update(entity.Id, entity);
            return newPost;
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
            entity.Id = id;
            // problem with multiple tags with same id in one dbContext.
            //_dbContext.Tags.UpdateRange(entity.Tags);

            //_dbContext.Tags.RemoveRange(entity.Tags);
            var entry = _dbContext.Set<Post>().Update(entity);
            await _dbContext.SaveChangesAsync();
            //foreach (var tag in entity.Tags)
            //{
            //    _dbContext.Entry(entity).State = EntityState.;
            //}

            return entry.Entity;
        }
    }
}
