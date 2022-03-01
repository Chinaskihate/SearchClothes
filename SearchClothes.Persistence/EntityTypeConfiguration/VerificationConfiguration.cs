using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Persistence.EntityTypeConfiguration
{
    public class VerificationConfiguration : IEntityTypeConfiguration<Verification>
    {
        public void Configure(EntityTypeBuilder<Verification> builder)
        {
            builder.HasKey(verif => verif.Id);
            builder.HasIndex(verif => verif.Id).IsUnique();
            builder.Property(verif => verif.Email).HasMaxLength(100);
            builder.Property(verif => verif.PasswordHash).HasMaxLength(100);
        }
    }
}
