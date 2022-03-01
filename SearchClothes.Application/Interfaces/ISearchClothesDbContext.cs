using Microsoft.EntityFrameworkCore;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchClothes.Application.Interfaces
{
    public interface ISearchClothesDbContext
    {
        DbSet<Post> Posts { get; set; }

        DbSet<Rate> Rates { get; set; }

        DbSet<Tag> Tags { get; set; }

        DbSet<User> Users { get; set; }

        public DbSet<Verification> Verifications { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
