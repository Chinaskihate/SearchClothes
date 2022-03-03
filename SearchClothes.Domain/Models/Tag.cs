using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Domain.Models
{
    public class Tag : DomainObject
    {
        public string Name { get; set; }

        [Required]
        public Guid CreatorId { get; set; }
    }
}
