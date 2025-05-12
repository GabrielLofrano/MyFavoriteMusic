using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMusic.Application.DTOs.Artista
{
    public class CreateArtistRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Imagem { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? OriginCountry { get; set; }
        public int? YearTraining { get; set; }
        public string? Slug { get; set; }
        public string? ArtisticName { get; set; }
        public ICollection<Domain.Entities.Album>? Albums { get; set; }
    }
}
