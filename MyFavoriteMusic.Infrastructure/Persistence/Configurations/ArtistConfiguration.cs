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
    internal class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .HasMaxLength(100);
            builder
                .Property(x => x.Imagem);
            builder
                .Property(x => x.BirthDate);
            builder
                .Property(x => x.RegistrationDate);
            builder
                .Property(x => x.OriginCountry);
            builder
                .Property(x => x.YearTraining);
            builder
                .Property(x => x.Slug);
            builder
                .Property(x => x.ArtisticName);

            builder.HasMany(a => a.Albums)
                .WithMany() 
                .UsingEntity(j => j.ToTable("ArtistAlbums")); 
        }
    }
}
