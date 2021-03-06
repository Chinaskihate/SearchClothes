using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Interfaces.DataServices
{
    public interface IPostDataService : IDataService<Post>
    {
        public Task<IEnumerable<Post>> GetByCreatorId(Guid creatorId);

        public Task<IEnumerable<Post>> GetByTitle(string title);

        public Task<IEnumerable<Post>> GetByTags(IEnumerable<Tag> tags);

        public Task<IEnumerable<Post>> GetByRate(double minRate);

        public Task<IEnumerable<Post>> GetPosts(string title, IEnumerable<Tag> tags, double minRate);
    }
}
