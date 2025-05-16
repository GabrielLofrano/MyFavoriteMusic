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
    public class UserRepository : IUserRepository
    {

        private readonly MyFavoriteMusicContext _context;

        public UserRepository(MyFavoriteMusicContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateAsync(User user)
        {
            await _context.SaveChangesAsync();
        }
    }
}
