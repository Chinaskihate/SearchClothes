using Microsoft.EntityFrameworkCore;
using SearchClothes.Application.Interfaces;
using SearchClothes.Domain.Models;
using SearchClothes.Persistence.EntityTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Persistence
{
    public class SearchClothesDbContext : DbContext, ISearchClothesDbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Verification> Verifications { get; set; }
    
        public SearchClothesDbContext(DbContextOptions<SearchClothesDbContext> options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PostConfiguration());
            builder.ApplyConfiguration(new RateConfiguration());
            builder.ApplyConfiguration(new TagConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new VerificationConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
