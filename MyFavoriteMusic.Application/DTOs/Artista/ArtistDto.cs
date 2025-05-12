using MyFavoriteMusic.Application.DTOs.Album;
using MyFavoriteMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMusic.Application.DTOs.Artista
{
    public class ArtistDto
    {
        public Guid Id { get;  set; }
        public string Name { get;  set; }
        public string? Description { get;  set; }
        public string? Imagem { get;  set; }
        public DateTime? BirthDate { get;  set; }
        public DateTime? RegistrationDate { get;  set; }
        public string? OriginCountry { get;  set; }
        public int? YearTraining { get;  set; }
        public string? Slug { get;  set; }
        public string? ArtisticName { get; set; }
        public ICollection<AlbumDto>? Albums { get;  set; }
    }
}
