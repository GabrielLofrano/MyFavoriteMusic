using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFavoriteMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMusic.Infrastructure.Persistence.Configurations
{
    internal class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Album");

            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Title)
                .HasMaxLength(250)
                .IsRequired();

            builder
                .Property(a => a.Rate)
                .HasColumnType("decimal(5,2)");
        }
    }
}
