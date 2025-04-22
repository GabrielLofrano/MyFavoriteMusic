using System.ComponentModel.DataAnnotations;

namespace MyFavoriteMusic.Api.DTOs.Album
{
    public class CreateAlbumRequest
    {
        public string? Title { get; set; }
        public decimal Rate { get; set; }
    }
}
