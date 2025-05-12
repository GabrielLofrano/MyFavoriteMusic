using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMusic.Domain.Entities
{
    public class Artist
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = null!;
        public string? Description { get; init; }
        public string? Imagem { get; init; }
        public DateTime? BirthDate { get; init; }
        public DateTime? RegistrationDate { get; init; }
        public string? OriginCountry { get; init; }
        public int? YearTraining { get; init; }
        public string? Slug { get; init; }
        public string? ArtisticName { get; init; }
        public ICollection<Album>? Albums { get; init; } = new List<Album>();

        public Artist With(
            string? name = null,
            string? description = null,
            string? imagem = null,
            DateTime? birthDate = null,
            DateTime? registrationDate = null,
            string? originCountry = null,
            int? yearTraining = null,
            string? slug = null,
            string? artisticName = null,
            ICollection<Album>? albums = null
        )
        {
            return new Artist
            {
                Id = this.Id,
                Name = name ?? this.Name,
                Description = description ?? this.Description,
                Imagem = imagem ?? this.Imagem,
                BirthDate = birthDate ?? this.BirthDate,
                RegistrationDate = registrationDate ?? this.RegistrationDate,
                OriginCountry = originCountry ?? this.OriginCountry,
                YearTraining = yearTraining ?? this.YearTraining,
                Slug = slug ?? this.Slug,
                ArtisticName = artisticName ?? this.ArtisticName,
                Albums = albums ?? this.Albums
            };
        }
    }
}
