using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFavoriteMusic.Domain.Entities;
using MyFavoriteMusic.Domain.Interfaces;
using MyFavoriteMusic.Infrastructure.Persistence.Contexts;

namespace MyFavoriteMusic.Infrastructure.Persistence.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {

        private readonly MyFavoriteMusicContext _context;

        public AlbumRepository(MyFavoriteMusicContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Album album)
        {
            await _context.Albums.AddAsync(album);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            return await _context.Albums.ToListAsync();
        }

        public async Task<Album> GetByIdAsync(Guid id)
        {
            return await _context.Albums.FindAsync(id);
        }

        public async Task UpdateAsync(Album album)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Album album)
        {
            _context.Remove(album);
            await _context.SaveChangesAsync();
        }
    }
}
