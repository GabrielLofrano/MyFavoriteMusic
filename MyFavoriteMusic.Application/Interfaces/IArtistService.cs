using MyFavoriteMusic.Api.DTOs.Album;
using MyFavoriteMusic.Application.DTOs.Album;
using MyFavoriteMusic.Application.DTOs.Artista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMusic.Application.Interfaces
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistDto>> ListArtistAsync();
        Task<ArtistDto> GetArtistByIdAsync(Guid id);
        Task<ArtistDto> GetArtistByNameAsync(string name);
        Task<Guid> CreateAsync(CreateArtistRequest request);
        Task UpdateAsync(Guid id, UpdateArtistRequest request);
        Task DeleteAsync(Guid id);
    }
}
