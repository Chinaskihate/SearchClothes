using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Domain.Models
{
    public class Tag : DomainObject
    {
        public Tag()
        {
            Posts = new List<Post>();
        }

        public string Name { get; set; }

        [Required]
        public Guid CreatorId { get; set; }

        public IList<Post> Posts { get; set; }

        public override bool Equals(object tag)
        {
            var otherTag = tag as Tag;
            if (otherTag is null)
            {
                return false;
            }
            return Id == otherTag.Id && Name == otherTag.Name && CreatorId == otherTag.CreatorId;
        }

        public static bool operator ==(Tag firstTag, Tag secondTag)
        {
            return firstTag.Equals(secondTag);
        }

        public static bool operator !=(Tag firstTag, Tag secondTag)
        {
            return !firstTag.Equals(secondTag);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + Name.GetHashCode() + CreatorId.GetHashCode();
        }
    }
}
