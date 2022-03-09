using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Domain.Models
{
    public class User : DomainObject
    {
        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public Guid Token { get; set; }

        public IList<Post> CreatedPosts { get; set; }

        public IList<Post> RatedPosts { get; set; }
    }
}
