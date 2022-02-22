using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Domain.Models
{
    public class Post
    {
        public Guid Id { get; set; }

        [Required]
        public Guid CreatorId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime LastEditTime { get; set; }

        public ICollection<Rate> Rates { get; set; }
    
        public ICollection<Tag> Tags { get; set; }
    }
}
