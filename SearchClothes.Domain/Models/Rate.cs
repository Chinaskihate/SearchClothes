﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Domain.Models
{
    public class Rate
    {
        public Guid UserId { get; set; }

        [Required]
        public Guid Id { get; set; }

        [Range(0, 5)]
        public int Value { get; set; }
    }
}
