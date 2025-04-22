using MyFavoriteMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMusic.Domain.Interfaces
{
     public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> GetAllAsync();
        Task<Album> GetByIdAsync(int id);
        Task AddAsync(Album album);
        Task UpdateAsync(Album album);
        Task DeleteAsync(Album album);
    }
}

