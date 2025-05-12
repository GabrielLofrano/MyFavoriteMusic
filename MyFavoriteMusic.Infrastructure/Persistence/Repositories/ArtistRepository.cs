using Microsoft.EntityFrameworkCore;
using MyFavoriteMusic.Domain.Entities;
using MyFavoriteMusic.Domain.Interfaces;
using MyFavoriteMusic.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFavoriteMusic.Infrastructure.Persistence.Repositories
{
    public class ArtistRepository : IArtistRepository
    {

        private readonly MyFavoriteMusicContext _context;

        public ArtistRepository(MyFavoriteMusicContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Artist artista)
        {
            await _context.Artists.AddAsync(artista);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Artist artista)
        {
            _context.Artists.Remove(artista);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            return await _context.Artists.Include(a => a.Albums) 
                                         .ToListAsync();
        }

        public async Task<Artist> GetByIdAsync(Guid id)
        {
            return await _context.Artists.Include(a => a.Albums)
                                         .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Artist artista)
        {
            _context.Update(artista);
            await _context.SaveChangesAsync();
        }
    }
}
