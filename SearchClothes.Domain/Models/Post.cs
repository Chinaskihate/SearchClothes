using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Domain.Models
{
    public class Post : DomainObject
    {
        [Required]
        public Guid CreatorId { get; set; }

        public string Title { get; set; }

        public string SellerLink { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime LastEditTime { get; set; }

        public IList<Rate> Rates { get; set; }
    
        public IList<Tag> Tags { get; set; }
    }
}
