using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        
        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public ICollection<Post> CreatedPosts { get; set; }

        public ICollection<Post> RatedPosts { get; set; }
    }
}
