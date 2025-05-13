using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMusic.Domain.Entities
{
    public class Song
    {
        public Guid Id { get; set; }
        public string Tittle { get; set; }
        public Guid AlbumId { get; set; }
        public Guid ArtistId { get; set; }
        public string Genre { get; set; }
    }
}
